using System;
using System.Linq;

namespace LargestHoarding
{
    /// <summary>
    /// https://open.kattis.com/problems/largesthoarding
    /// </summary>
    class Program
    {
        const int COST = 50;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Building[] buildings = new Building[n];
            for (int i = 0; i < n; i++)
                buildings[i] = new Building(Console.ReadLine());
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                if (buildings[i].Height == 0)
                    continue;
                int bestArea = buildings[i].Area;
                int curHeight = buildings[i].Height;
                int curWidth = buildings[i].Width;
                for (int j = i + 1; j < n; j++)
                {
                    if (buildings[j].Height == 0)
                        break;
                    if (buildings[j].Height < curHeight)
                    {
                        curHeight = buildings[j].Height;
                    }
                    curWidth += buildings[j].Width;
                    bestArea = Math.Max(bestArea, curWidth * curHeight);
                }
                max = Math.Max(max, bestArea);
            }
            Console.WriteLine(max * COST);
        }

        struct Building
        {
            public int Width;
            public int Height;
            public int Area => Width * Height;
            public Building(string line)
            {
                int[] parsed = line.Split(' ').Select(x => int.Parse(x)).ToArray();
                Height = parsed[0];
                Width = parsed[1];
            }
        }
    }
}
