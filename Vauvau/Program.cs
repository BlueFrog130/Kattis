using System;
using System.Collections.Generic;
using System.Linq;

namespace Vauvau
{
    class Program
    {
        static void Main(string[] args)
        {
            // [A B C D]
            List<int> abcd = Console.ReadLine().Split(" ").Select(n => int.Parse(n)).ToList();

            Doge d1 = new Doge(abcd[0], abcd[1]);
            Doge d2 = new Doge(abcd[2], abcd[3]);

            // [P M G]
            IEnumerable<int> pmg = Console.ReadLine().Split(" ").Select(n => int.Parse(n));



        }

        class Doge
        {
            public int Aggressive { get; }
            public int Calm { get; }

            public Doge(int a, int c)
            {
                Aggressive = a;
                Calm = c;
            }

            public bool IsAgro(int time)
            {
                int t = 0;
                bool agro = true;
                while (true)
                {

                }
            }
        }
    }
}
