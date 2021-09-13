using System;

namespace ExplodingBatteries
{
    /// <summary>
    /// https://open.kattis.com/problems/batteries
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Current at which battery known to explode [1..4711]
            int n = int.Parse(Console.ReadLine());

            if (n == 0)
                return;

            Console.WriteLine(Tests(n - 1));

            Main(args);
        }

        static int Tests(int x)
        {
            return (int)Math.Ceiling((Math.Sqrt(1 + 8 * x) - 1) / 2);
        }
    }
}
