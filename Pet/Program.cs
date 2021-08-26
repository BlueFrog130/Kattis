using System;
using System.Collections.Generic;
using System.Linq;

namespace Pet
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, IEnumerable<int>> contestants = new Dictionary<int, IEnumerable<int>>();
            int i = 1;
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                contestants.Add(i, line.Split(" ").Select(n => int.Parse(n)));
                i++;
            }
            int winner = contestants.Max(c => c.Value.Sum());
            int key = contestants.First(c => c.Value.Sum() == winner).Key;

            Console.WriteLine($"{key} {winner}");
        }
    }
}
