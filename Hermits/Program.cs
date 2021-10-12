using System;
using System.Collections.Generic;
using System.Linq;

namespace Hermits
{
    /// <summary>
    /// https://open.kattis.com/problems/hermits
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Street[] streets = Console.ReadLine().Split(" ").Select((x, j) => new Street(j + 1, int.Parse(x))).ToArray();
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                IEnumerable<int> pair = Console.ReadLine().Split(" ").Select(x => int.Parse(x));
                streets[pair.First() - 1].Crosses.Add(streets[pair.Last() - 1]);
                streets[pair.Last() - 1].Crosses.Add(streets[pair.First() - 1]);
            }
            Street best = streets.Aggregate((current, next) => current.GetPeople() > next.GetPeople() ? next : current);
            Console.WriteLine(best.S);
        }

        class Street
        {
            public int S { get; }
            public int People { get; }

            public List<Street> Crosses { get; }

            public Street(int s, int p)
            {
                S = s;
                People = p;
                Crosses = new List<Street>();
            }

            public int GetPeople()
            {
                return People + Crosses.Sum(c => c.People);
            }
        }
    }
}
