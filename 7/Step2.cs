using System.Globalization;
var input = new List<string>();
string line;
while ((line = Console.ReadLine()) is not (null or ""))
    input.Add(line);
var pathMatrix = new long[input.Count][];
pathMatrix[0] = new long[input[0].Length];
for (int i = 1; i < input.Count; i++)
{
    var chars = input[i].ToCharArray();
    pathMatrix[i] = new long[chars.Length];
    for (int j = 0; j < chars.Length; j++)
    {
        long inputNumber;
        long prevInput;
        if (chars[j] == '^')
        {
            if(!long.TryParse(input[i-1][j].ToString(), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out inputNumber))
            {
                //Console.WriteLine($"Error parsing input number at row {i}, column {j}");
                //Console.WriteLine(input[i-1]);
                continue;
            }
            inputNumber = pathMatrix[i-1][j];
            if (j > 0)
            {
                long num;
                if ((num = pathMatrix[i][j - 1]) > 0)
                {
                    chars[j - 1] = (num + inputNumber).ToString("X")[0];
                    pathMatrix[i][j - 1] = num + inputNumber;
                }
                else
                {
                    chars[j - 1] = inputNumber.ToString("X")[0];
                    pathMatrix[i][j - 1] = inputNumber;
                }
                if ((num = pathMatrix[i][j + 1]) > 0)
                {
                    chars[j + 1] = (num + inputNumber).ToString("X")[0];
                    pathMatrix[i][j + 1] = num + inputNumber;
                }
                else
                {
                    chars[j + 1] = inputNumber.ToString("X")[0];
                    pathMatrix[i][j + 1] = inputNumber;
                }
            }

        }
        else if ((prevInput = pathMatrix[i - 1][j]) > 0)
        {
            if(chars[j] == '.')
            {
                chars[j] = prevInput.ToString("X")[0];
                pathMatrix[i][j] = prevInput;
            }
            else
            {
                chars[j] = (int.Parse(chars[j].ToString(), NumberStyles.HexNumber, CultureInfo.InvariantCulture) + prevInput).ToString("X")[0];
                pathMatrix[i][j] = pathMatrix[i][j] + prevInput;
            }
        }
        else if (input[i - 1][j] == 'S')
        {
            chars[j] = '1';
            pathMatrix[i][j] = 1;
        }
    }
    input[i] = new string(chars);
    Console.WriteLine(input[i]);
    //Console.WriteLine(string.Join(',', pathMatrix[i]));
}

long result = 0;

result = pathMatrix[pathMatrix.Length - 1].Sum();

Console.WriteLine("Result: " + result);