var ranges = new List<(long Key, long Value)>();
var items = new List<string>();
while (true)
{
    var input = Console.ReadLine();
    if (input == "" || input == null)
        break;
    ranges.Add(new (long.Parse(input.Split('-')[0]), long.Parse(input.Split('-')[1])));
}
Console.WriteLine("Ranges loaded.");
while(true)
{
    var input = Console.ReadLine();
    if (input == "" || input == null) 
        break;
    items.Add(input);
}
Console.WriteLine("Items loaded.");
var result = 0;
foreach(var item in items)
{
    if(ranges.Any(r => long.Parse(item) >= r.Key && long.Parse(item) <= r.Value))
    {
        result++;
        Console.WriteLine($"Item {item} is in a range. Current count: {result} ");  
    }
}

Console.WriteLine("Result: " + result);