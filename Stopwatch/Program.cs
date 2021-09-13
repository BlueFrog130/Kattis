using System;

namespace Stopwatch
{
    /// <summary>
    /// https://open.kattis.com/problems/stopwatch
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int t = 0;
            int last = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i % 2 != 0)
                    t += num - last;

                last = num;
            }

            if (n % 2 != 0)
                Console.WriteLine("still running");
            else
                Console.WriteLine(t);
        }
    }
}
