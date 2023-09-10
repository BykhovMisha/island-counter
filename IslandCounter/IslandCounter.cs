internal class IslandCounter
{
    private static readonly string WaterValue = "0";

    public int Solve(string mapString)
    {
        var map = GetMap(mapString);

        if (map.Length == 0 || map[0].Length == 0)
        {
            return 0;
        }

        var stack = new Stack<(int i, int j)>();
        var maxI = map.Length - 1;
        var maxJ = map[0].Length - 1;

        Action drownIsland = () =>
        {
            while (stack.Count > 0)
            {
                var (i, j) = stack.Pop();
                map[i][j] = WaterValue;

                if (i > 0 && map[i - 1][j] != WaterValue)
                {
                    stack.Push((i - 1, j));
                }

                if (i < maxI && map[i + 1][j] != WaterValue)
                {
                    stack.Push((i + 1, j));
                }

                if (j > 0 && map[i][j - 1] != WaterValue)
                {
                    stack.Push((i, j - 1));
                }

                if (j < maxJ && map[i][j + 1] != WaterValue)
                {
                    stack.Push((i, j + 1));
                }
            }
        };

        var result = 0;

        for (var i = 0; i < map.Length; i++)
        {
            for (var j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] != WaterValue)
                {
                    result++;
                    stack.Push((i, j));
                    drownIsland();
                }
            }
        }

        return result;
    }

    private static string[][] GetMap(string mapString)
    {
        return mapString.Split(';', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray())
            .ToArray();
    }
}
