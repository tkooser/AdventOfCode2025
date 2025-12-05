long result = 0;
while(true)
{
    var input = Console.ReadLine();
    if(input == null || input == "")
    {
        break;
    }
    int[] digits = new int[12];
    var currentIndex = 0;

    for(int i = 0; i < 12; i++)
    {
        digits[i] = FindDigit(input, i == 0 ? 0 : currentIndex + 1, i, out currentIndex);
    }

    var joltage = long.Parse(string.Join("", digits));
    Console.WriteLine($"{input}: {joltage}");
    result += joltage;
}
Console.WriteLine("Result: " + result);

int FindDigit(string input, int startIndex, int currentDigitLocation, out int foundIndex)
{
    //Console.WriteLine($"Start index: {startIndex}");
    foreach (var digit in "987654321")
    {
        //Console.WriteLine($"Looking for digit: {digit}");
        var index = input.IndexOf(digit, startIndex);
        if(index >= input.Length - (11 - currentDigitLocation))
        {
            //Console.WriteLine("Skipping digit at the end");
            continue;
        }
        if(index >= 0)
        {
            //Console.WriteLine($"Found digit {digit} at index {index}");
            foundIndex = index;
            return int.Parse($"{digit}");
        }
    }
    throw new Exception("No digit found");
}