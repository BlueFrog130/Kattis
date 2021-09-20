using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimePath
{
    static class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                int source = int.Parse(line[0]);
                int target = int.Parse(line[1]);

                int current = source;
                int steps = 0;
                while (current != target)
                {
                    steps++;
                    int[] possibilities = new int[4];
                    for (int j = 0; j < 4; j++)
                    {
                        possibilities[j] = current.IncrementDigit(j);
                    }
                    IEnumerable<int> primes = possibilities.Where(x => x.IsPrime());
                    if (primes.Count() > 1)
                        Console.WriteLine($"{current} has more than 1 possible number");
                }
                Console.WriteLine(steps);
            }
        }

        static bool IsPrime(this int number)
        {
            for (int i = 2; i <= number/i; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        static int DigitAt(this int num, int i)
        {
            int x = (int)Math.Pow(10, i);
            return ((num % (x * 10)) - (num % x)) / x;
        }

        static int IncrementDigit(this int num, int i)
        {
            int x = (int)Math.Pow(10, i);
            return num + x;
        }
    }
}
