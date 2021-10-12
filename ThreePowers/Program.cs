using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ThreePowers
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != "0")
                Solve(ulong.Parse(line) - 1);
        }

        static void Solve(ulong n)
        {
            List<BigInteger> v = new List<BigInteger>();
            BigInteger c = 1;
            while (n > 0)
            {
                if (n % 2 == 1)
                    v.Add(c);
                c *= 3;
                n /= 2;
            }
            string nums = string.Join(", ", v.Select(x => x.ToString()));
            Console.WriteLine("{ " + nums + " }");
        }
    }
}
