var input = new List<List<long>>();
var operations = new List<string>();
while (true)
{
    var line = Console.ReadLine();
    if (line == "" || line == null)
        break;
    var splitLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    if(!long.TryParse(splitLine[0], out var _))
    {
        operations.AddRange(splitLine);
        break;
    }
    input.Add(splitLine.Select(long.Parse).ToList());
}
Console.WriteLine("Input loaded.");

Dictionary<string, Func<long, long, long>> operators = new Dictionary<string, Func<long, long, long>>();
        operators.Add("+", (x, y) => x + y);
        operators.Add("-", (x, y) => x - y);
        operators.Add("*", (x, y) => x * y);
        operators.Add("/", (x, y) => x / y);

long result = 0;
for(int i = 0; i < operations.Count; i++)
{
    var opStr = operations[i];
    var op = operators[opStr];
    long currentResult = -1;
    foreach(var row in input)
    {   if(currentResult == -1)
        {
            currentResult = (long)row[i];
            Console.WriteLine($"Starting new row with initial value {currentResult}");
            continue;
        }
        Console.WriteLine($"Applying operation {opStr} to {currentResult} and {row[i]}");
        currentResult = op(currentResult, (long)row[i]);
    }
    Console.WriteLine($"Operation {opStr} resulted in {currentResult}");
    result += currentResult;
}

Console.WriteLine("Result: " + result);