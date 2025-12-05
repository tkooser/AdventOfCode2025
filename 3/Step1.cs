var result = 0;
while(true)
{
    var input = Console.ReadLine();
    if(input == null || input == "")
    {
        break;
    }
    int first = FindDigit(input, 0, out int firstIndex);
    int second = FindDigit(input, firstIndex + 1, out int secondIndex);
    var joltage = int.Parse($"{first}{second}");
    Console.WriteLine($"{input}: {joltage}");
    result += joltage;
}
Console.WriteLine("Result: " + result);

int FindDigit(string input, int startIndex, out int foundIndex)
{
    foreach (var digit in "987654321")
    {
        var index = input.IndexOf(digit, startIndex);
        if(startIndex == 0 && index == input.Length - 1)
        {
            continue;
        }
        if(index >= 0)
        {
            foundIndex = index;
            return int.Parse($"{digit}");
        }
    }
    throw new Exception("No digit found");
}