using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimePath
{
    /// <summary>
    /// https://open.kattis.com/problems/primepath
    /// </summary>
    static class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] split = Console.ReadLine().Split();
                int from = int.Parse(split[0]);
                int to = int.Parse(split[1]);

                int cost = Cost(from, to);
                if (cost > -1)
                    Console.WriteLine(cost);
                else
                    Console.WriteLine("Impossible");
            }
        }

        static int Cost(int from, int to)
        {
            if (from == to)
                return 0;
            Dictionary<int, int> nodes = new Dictionary<int, int>();
            Queue<int> queue = new Queue<int>();
            nodes.Add(from, 0);
            queue.Enqueue(from);

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                nodes.TryGetValue(u, out int currentDepth);
                IEnumerable<int> primes = u.AdjacentPrimes();
                foreach (int prime in primes)
                {
                    if (prime == to)
                        return currentDepth + 1;
                    if (!nodes.ContainsKey(prime))
                    {
                        nodes.Add(prime, currentDepth + 1);
                        queue.Enqueue(prime);
                    }
                }
            }
            return -1;
        }

        static IEnumerable<int> AdjacentPrimes(this int prime)
        {
            List<int> nums = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                int current = prime.DigitAt(i);
                int resetPrime = prime.ResetDigit(i);
                int pow = (int) Math.Pow(10, i);
                IEnumerable<int> digitPrimes = Enumerable.Range(0, 10).Where(x => x != current).Select(x => resetPrime + (x * pow)).Where(IsPrime);
                nums.AddRange(digitPrimes);
            }
            return nums;
        }

        static int DigitAt(this int num, int x)
        {
            int i = (int) Math.Pow(10, x);
            return num / i % 10;
        }

        static int ResetDigit(this int num, int x)
        {
            int i = (int)Math.Pow(10, x);
            return num - (num.DigitAt(x) * i);
        }

        static bool IsPrime(this int num)
        {
            if (num % 2 == 0)
                return false;
            if (num < 1000)
                return false;
            for (int i = 3; i * i <= num; i += 2)
                if (num % i == 0)
                    return false;
            return true;
        }
    }
}
