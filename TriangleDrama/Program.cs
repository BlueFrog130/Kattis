using System;
using System.Linq;

namespace TriangleDrama
{
    /// <summary>
    /// https://open.kattis.com/problems/triangledrama
    /// INCOMPLETE
    /// </summary>
    static class Program
    {
        static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine());
            int[][] people = new int[p][];
            for (int i = 0; i < p; i++)
            {
                people[i] = Console.ReadLine()
                    .Split(" ")
                    .Select(x => int.Parse(x))
                    .ToArray();
            }
            int[] abc = new int[0];
            int max = int.MinValue;
            for (int i = 0; i < p; i++)
                for (int j = i + 1; j < p; j++)
                    for (int k = j + 1; k < p; k++)
                    {
                        int c = people[i][j] * people[i][k] * people[j][k];
                        if (c > max)
                        {
                            abc = new int[] { i, j, k };
                            max = c;
                        }
                    }

            Console.WriteLine(string.Join(" ", abc.Select(x => x + 1).OrderBy(x => x)));

        }
    }
}
