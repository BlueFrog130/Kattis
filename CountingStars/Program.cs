using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingStars
{
    /// <summary>
    /// https://open.kattis.com/problems/countingstars
    /// </summary>
    static class Program
    {
        static void Main(string[] args)
        {
            string line;
            int c = 1;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                int[] grid = line.Split(" ").Select(w => int.Parse(w)).ToArray();
                Pixel[,] pixels = new Pixel[grid[0], grid[1]];

                for (int i = 0; i < pixels.GetLength(0); i++)
                {
                    char[] p = Console.ReadLine().ToCharArray();
                    for (int j = 0; j < pixels.GetLength(1); j++)
                    {
                        pixels[i, j] = new Pixel(p[j]);
                    }
                }

                int stars = 0;
                for (int i = 0; i < pixels.GetLength(0); i++)
                {
                    for (int j = 0; j < pixels.GetLength(1); j++)
                    {
                        stars += fill(ref pixels, i, j);
                    }
                }

                Console.WriteLine($"Case {c}: {stars}");
                c++;
            }
        }

        struct Pixel
        {
            public char C { get; }
            public bool Used { get; set; }

            public Pixel(char c)
            {
                C = c;
                Used = c == '#';
            }
        }

        static int fill(ref Pixel[,] pixels, int row, int col)
        {
            int rows = pixels.GetLength(0);
            int cols = pixels.GetLength(1);
            if (row < 0 || col < 0 || row >= rows || col >= cols || pixels[row, col].Used)
                return 0;

            pixels[row, col].Used = true;

            fill(ref pixels, row + 1, col);
            fill(ref pixels, row - 1, col);
            fill(ref pixels, row, col + 1);
            fill(ref pixels, row, col - 1);

            return 1;
        }
    }
}
