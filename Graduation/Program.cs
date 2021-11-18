using System;
using System.Collections.Generic;
using System.Linq;

namespace Graduation
{
    /// <summary>
    /// https://open.kattis.com/problems/skolavslutningen
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            char[,] lineup = new char[input[0], input[1]];
            for (int i = 0; i < input[0]; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < input[1]; j++)
                    lineup[i, j] = line[j];
            }
            HashSet<char> usedClasses = new HashSet<char>();
            int colors = 0;
            for (int j = 0; j < lineup.GetLength(1); j++)
            {
                char[] col = new char[lineup.GetLength(0)];
                for (int i = 0; i < lineup.GetLength(0); i++)
                    col[i] = lineup[i, j];
                if (col.All(c => !usedClasses.Contains(c)))
                {
                    colors++;
                }
                usedClasses.UnionWith(col);
            }
            Console.WriteLine(colors);
        }
    }
}
