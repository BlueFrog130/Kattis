using System;
using System.Linq;

namespace MillionaireMadness
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(" ");
            int m = int.Parse(line[0]);
            int n = int.Parse(line[1]);

            int[,] vault = new int[m,n];

            for (int i = 0; i < m; i++)
            {
                int[] nums = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
                for (int j = 0; j < n; j++)
                    vault[i, j] = nums[j];
            }

            int[] x = { 0, 0, 1, -1 };
            int[] y = { 1, -1, 0, 0 };
        }
    }
}
