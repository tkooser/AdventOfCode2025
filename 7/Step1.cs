var input = new List<string>();
string line;
while((line = Console.ReadLine()) is not (null or ""))
    input.Add(line);

List<int> beamIndexes = new List<int>();
beamIndexes.Add(input[0].IndexOf('S'));
var splits = 0;
for (int r = 0; r < input.Count; r++)
{   
    var row = input[r];
    Console.WriteLine($"{row} - Beam Indexes: {string.Join(",", beamIndexes)}");
    var lineSplits = new List<int>();
    int startIndex = 0;
    int index;
    while((index = row.IndexOf('^', startIndex)) != -1)
    {
        lineSplits.Add(index);
        startIndex = index + 1;
    }
    IEnumerable<int> hits;
    if((hits = lineSplits.Intersect(beamIndexes)).Any())
    {
        splits += hits.Count();
        beamIndexes = hits.Select(i => i + 1).Concat(hits.Select(i => i - 1)).Concat(beamIndexes).Distinct().Where(i => !hits.Contains(i)).ToList();
        var chars = row.ToCharArray();
        foreach(var beamIndex in beamIndexes)
        {
            if (beamIndex >= 0 && beamIndex < chars.Length)
                chars[beamIndex] = '|';
        }
        input[r] = new string(chars);
    }
}

foreach(var row in input)
{
    Console.WriteLine(row);
}
Console.WriteLine("Result: " + splits);
