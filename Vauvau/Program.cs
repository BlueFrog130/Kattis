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

            IEnumerable<int> dogeAtt1 = pmg.Select(x => d1.IsAgro(x));
            IEnumerable<int> dogeAtt2 = pmg.Select(x => d2.IsAgro(x));

            IEnumerable<int> attacks = dogeAtt1.Select((a, i) => a + dogeAtt2.ElementAt(i));
            foreach (int i in attacks)
            {
                switch (i)
                {
                    case 2:
                        Console.WriteLine("both");
                        break;
                    case 1:
                        Console.WriteLine("one");
                        break;
                    default:
                        Console.WriteLine("none");
                        break;
                }
            }
        }

        class Doge
        {
            public int Aggressive { get; }
            public int Calm { get; }

            public int Interval => Aggressive + Calm;

            public Doge(int a, int c)
            {
                Aggressive = a;
                Calm = c;
            }

            public int IsAgro(int time)
            {
                int t = time % Interval;
                if (t == 0 || t > Aggressive)
                    return 0;
                return 1;
            }
        }
    }
}
