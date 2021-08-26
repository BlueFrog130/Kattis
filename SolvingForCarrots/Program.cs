using System;
using System.Collections.Generic;
using System.Linq;

namespace SolvingForCarrots
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> input = Console.ReadLine().Split(" ").Select(s => int.Parse(s));
            int n = input.First();
            int p = input.Last();

            for (int i = 0; i < n; i++)
                Console.ReadLine();

            Console.WriteLine(p);
        }
    }
}
