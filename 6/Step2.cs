var rawInput = new List<string>();
var input = new List<List<long>>();
var operations = new List<(string operation, int columnLength)>();

while (true)
{
    var line = Console.ReadLine();
    if (line == "" || line == null)
        break;
    rawInput.Add(line);
}
foreach(var rawOpChar in rawInput[rawInput.Count - 1].ToCharArray())
{
    if(rawOpChar != ' ')
    {
        operations.Add((rawOpChar.ToString(), 0));
    }
    else
    {
        if(operations.Count > 0)
        {
            var lastOp = operations[operations.Count - 1];
            operations[operations.Count - 1] = (lastOp.operation, lastOp.columnLength + 1);
        }
    }
}
//Add an extra at the end I guess?
operations[operations.Count - 1] = (operations[operations.Count - 1].operation, operations[operations.Count - 1].columnLength + 1);

var offset = 0;
var matricies = new List<(string operation, int columnLength, char[][] matrix)>();
foreach(var operation in operations)
{
    char[][] matrix = new char[rawInput.Count - 1][];
    for(int i = 0; i < rawInput.Count - 1; i++)
    {
        //Console.WriteLine(operation.columnLength);
        for(int j = 0; j < operation.columnLength; j++)
        {
            //Console.WriteLine($"i: {i}, j: {j}, rawInput: {rawInput[i][j]}");
            if(j == 0)
            {
                matrix[i] = new char[operation.columnLength];
            }
            matrix[i][j] = rawInput[i][j + offset];
            Console.Write(matrix[i][j]);
        }
        Console.WriteLine("");
    }
    Console.Write($"{operation.operation}\n");
    offset += operation.columnLength + 1;
    matricies.Add(new (operation.operation, operation.columnLength, matrix));
}
Console.WriteLine("Input loaded.");

Dictionary<string, Func<long, long, long>> operators = new Dictionary<string, Func<long, long, long>>();
        operators.Add("+", (x, y) => x + y);
        operators.Add("-", (x, y) => x - y);
        operators.Add("*", (x, y) => x * y);
        operators.Add("/", (x, y) => x / y);

long result = 0;
for(int i = 0; i < matricies.Count; i++)
{
    var opStr = matricies[i].operation;
    var op = operators[opStr];
    long currentResult = -1;
    for(int j = matricies[i].columnLength - 1; j >= 0; j--)
    {
        Console.WriteLine("Processing column " + j);
        var numStr = "";
        var matrix = matricies[i].matrix;
        for(int k = 0; k < matrix.Length; k++)
        {
            numStr += matrix[k][j];
        }
        Console.WriteLine($"Parsed number string: {numStr}");
        if(currentResult == -1)
        {
            currentResult = long.Parse(numStr);
            Console.WriteLine($"Starting new row with initial value {currentResult}");
            continue;
        }
        Console.WriteLine($"Applying operation {opStr} to {currentResult} and {numStr}");
        currentResult = op(currentResult, long.Parse(numStr));
    }
    Console.WriteLine($"Operation {opStr} resulted in {currentResult}");
    result += currentResult;
}

Console.WriteLine("Result: " + result);