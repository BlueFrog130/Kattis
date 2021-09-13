using System;
using System.Collections.Generic;

namespace SafeHouses
{
    /// <summary>
    /// https://open.kattis.com/problems/safehouses
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Tuple<int, int>> spies = new List<Tuple<int, int>>(n);
            List<Tuple<int, int>> houses = new List<Tuple<int, int>>(n);

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    if (line[j] == 'S')
                        spies.Add(new Tuple<int, int>(i, j));
                    else if (line[j] == 'H')
                        houses.Add(new Tuple<int, int>(i, j));
                }
            }

            int max = 0;
            foreach (Tuple<int, int> s in spies)
            {
                int d = int.MaxValue;
                foreach (Tuple<int, int> h in houses)
                {
                    d = Math.Min(d, Dist(s, h));
                }
                max = Math.Max(max, d);
            }

            Console.WriteLine(max);
        }

        static int Dist(Tuple<int, int> t1, Tuple<int, int> t2)
        {
            return Math.Abs(t1.Item1 - t2.Item1) + Math.Abs(t1.Item2 - t2.Item2);
        }
    }
}
