using System;

namespace Heliocentric
{
    /// <summary>
    /// https://open.kattis.com/problems/heliocentric
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int c = 0;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                string[] s = line.Split(" ");
                int earth = int.Parse(s[0]);
                int mars = int.Parse(s[1]);
                int day = 0;
                while (earth != mars || earth != 0)
                {
                    day++; earth++; mars++;
                    if (earth == 365)
                        earth = 0;
                    if (mars == 687)
                        mars = 0;
                }
                c++;
                Console.WriteLine($"Case {c}: {day}");
            }
        }
    }
}
