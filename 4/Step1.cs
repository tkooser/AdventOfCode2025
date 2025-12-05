var grid = new List<List<char>>();
var result = 0;
while (true)
{
    var input = Console.ReadLine();
    //Console.WriteLine(input);
    if (input == "" || input == null)
        break;
    grid.Add(input.ToCharArray().ToList());
}
var offsets = new (int x, int y)[]
{
    (-1, -1),
    (-1, 1),
    (-1, 0),
    (1, -1),
    (1, 1),
    (1, 0),
    (0, 1),
    (0, -1)
};

for (int i = 0; i < grid.Count; i++)
{
    for (int j = 0; j < grid[i].Count; j++)
    {
        var currentItem = new[] { i, j };
        if(grid[i][j] != '@')
        {
            continue;
        }
        var currentCount = 0;
        foreach (var offset in offsets)
        {
            var checkItem = new  int[2] { currentItem[0] + offset.x, currentItem[1] + offset.y };
            if (checkItem[0] < 0 || checkItem[0] >= grid[i].Count || checkItem[1] < 0 || checkItem[1] >= grid.Count)
                continue;
            if(grid[checkItem[0]][checkItem[1]] == '@')
            {
                currentCount++;
            }
            if(currentCount >= 4)
            {
                break;
            }
        }
        if (currentCount < 4)
        {
            result++;
        }
    }
}

Console.WriteLine("Result: " + result);