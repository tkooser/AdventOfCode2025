var ranges = new List<(long Key, long Value)>();
while (true)
{
    var input = Console.ReadLine();
    if (input == "" || input == null)
        break;
    ranges = CheckOverlap(ranges, long.Parse(input.Split('-')[0]), long.Parse(input.Split('-')[1]));
}
Console.WriteLine("Ranges loaded.");
long result = 0;
foreach (var range in ranges)
{
    result += (range.Value - range.Key) + 1;
}

Console.WriteLine("Result: " + result);

List<(long Key, long Value)> CheckOverlap(List<(long Key, long Value)> ranges, long newStart, long newEnd)
{
    for(int i = 0; i < ranges.Count; i++)
    {
        var range = ranges[i];
        if(newStart <= range.Item2 && newEnd >= range.Item1)
        {
            // Overlap
            var mergedStart = Math.Min(newStart, range.Item1);
            var mergedEnd = Math.Max(newEnd, range.Item2);
            ranges.RemoveAt(i);
            return CheckOverlap(ranges, mergedStart, mergedEnd);
        }
    }
    ranges.Add((newStart, newEnd));
    return ranges;
}