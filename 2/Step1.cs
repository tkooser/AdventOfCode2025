var input = Console.ReadLine().Split(',');
long result = 0;
foreach (var range in input)
{
    foreach(var item in GetRange(range))
    {
        var itemStr = item.ToString();
        if(itemStr.Length % 2 != 0)
            continue;
        var debug = "";
        if(itemStr.Substring(0,itemStr.Length/2) == itemStr.Substring(itemStr.Length / 2)){
            result += item;
            debug = $"Added {item}";
        }
        Console.WriteLine($"{itemStr}: {itemStr.Substring(0,itemStr.Length/2)} {itemStr.Substring(itemStr.Length/2)} {debug}");
    }
}
Console.WriteLine(result);

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