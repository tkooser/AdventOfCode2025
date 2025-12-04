var input = Console.ReadLine().Split(',');
long result = 0;
foreach (var range in input)
{
    foreach(var item in GetRange(range))
    {
        var itemStr = item.ToString();
        var debug = "";
        Console.Write($"{itemStr}: ");
        if(CheckParts(itemStr)){
            result += item;
            Console.Write( $" Added {item}");
        }
        Console.WriteLine($"");
    }
}
Console.WriteLine("Result: " + result);

IEnumerable<long> GetRange(string range)
{
    var parts = range.Split('-');
    var start = long.Parse(parts[0]);
    var end = long.Parse(parts[1]);
    for (long i = start; i <= end; i++)
    {
        yield return i;
    }
}

bool CheckParts(string itemStr, int partLength = 1)
{
    if(partLength > itemStr.Length / 2)
        return false;
    var parts = GetParts(itemStr, partLength).ToList();
    var _return = parts.Distinct().Count() == 1;
    if(_return){
        Console.Write(string.Join(", ", parts));
        return true;
    }
    do
    {
        partLength++;
        _return = CheckParts(itemStr, partLength);
        if(_return)
            return true;
    }
    while(partLength < itemStr.Length / 2);
    return false;
}

IEnumerable<string> GetParts(string itemStr, int partLength = 1)
{
    for(int i = 0; i < itemStr.Length; i += partLength)
    {
        if(i + partLength > itemStr.Length)
        {
            yield return "Nope";
        }
        else
        {
            yield return itemStr.Substring(i, partLength); 
        }
    }
}