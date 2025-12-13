using System.Numerics;

const int NumToTake = 1000;

var x = new List<int>();
var y = new List<int>();
var z = new List<int>();
string line;
int pointIndex = 0;
while ((line = Console.ReadLine()) is not (null or ""))
{
    x.Add(int.Parse(line.Split(',')[0]));
    y.Add(int.Parse(line.Split(',')[1]));
    z.Add(int.Parse(line.Split(',')[2]));
    pointIndex++;
}
Console.WriteLine("Points loaded.");

var distances = new List<(int PointIndex1, int PointIndex2, long DistanceSquared)>();

Parallel.For(0, x.Count, i =>
{
    int vecSize = Vector<long>.Count;

    // Temporary arrays to hold the differences
    Span<long> dx = stackalloc long[vecSize];
    Span<long> dy = stackalloc long[vecSize];
    Span<long> dz = stackalloc long[vecSize];
    int xi = x[i], yi = y[i], zi = z[i];
    for (int jStart = i + 1; jStart < x.Count; jStart += vecSize)
    {
        int remaining = Math.Min(vecSize, x.Count - jStart);


        for (int v = 0; v < remaining; v++)
        {
            dx[v] = x[jStart + v] - xi;
            dy[v] = y[jStart + v] - yi;
            dz[v] = z[jStart + v] - zi;
        }

        var dxVec = new Vector<long>(dx);
        var dyVec = new Vector<long>(dy);
        var dzVec = new Vector<long>(dz);

        var distSqVec = dxVec * dxVec + dyVec * dyVec + dzVec * dzVec;

        for (int v = 0; v < remaining; v++)
        {
            var distSq = distSqVec[v];
            int j = jStart + v;
            lock (distances)
            {
                distances.Add(new(i, j, distSq));
            }

        }
    }
});

Console.WriteLine("Distances calculated.");
distances.Sort((a, b) => a.DistanceSquared.CompareTo(b.DistanceSquared));
var topPairs = distances.Take(NumToTake);

var parent = new int[x.Count];
var rank = new int[x.Count];

for (int i = 0; i < x.Count; i++)
{
    parent[i] = i;
    rank[i] = 0;
}

foreach (var distance in topPairs)
{
    Union(parent, rank, distance.PointIndex1, distance.PointIndex2);
}

var networkSizes = new Dictionary<int, int>();
for (int i = 0; i < x.Count; i++)
{
    int root = Find(parent, i);
    if (!networkSizes.ContainsKey(root))
        networkSizes[root] = 0;
    networkSizes[root]++;
}

var result = networkSizes.Values.OrderByDescending(x => x).Take(3).Aggregate(1, (acc, x) => acc * x);
Console.WriteLine("Result: " + result);

int Find(int[] parent, int x)
{
    if (parent[x] != x)
    {
        parent[x] = Find(parent, parent[x]);
    }
    return parent[x];
}

void Union(int[] parent, int[] rank, int x, int y)
{
    int rootX = Find(parent, x);
    int rootY = Find(parent, y);

    if (rootX != rootY)
    {
        if (rank[rootX] > rank[rootY])
        {
            parent[rootY] = rootX;
        }
        else if (rank[rootX] < rank[rootY])
        {
            parent[rootX] = rootY;
        }
        else
        {
            parent[rootY] = rootX;
            rank[rootX]++;
        }
    }
}