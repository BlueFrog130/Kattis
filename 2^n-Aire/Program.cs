using System;

namespace _2_n_Aire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] split = Console.ReadLine().Split(' ');
            int n = int.Parse(split[0]);
            double t = double.Parse(split[1]);

            if (n == 0 && t == 0)
                return;

            double f = Math.Pow(2, n);
            double eq, prize;
            for (int i = n - 1; i >= 0; i--)
            {
                prize = Math.Pow(2, i);
                eq = prize / f;
                if (eq <= t)
                    f = (t + 1) / 2 * f;
                else
                    f = (eq - t) / (1 - t) * prize + (1 - eq) / (1 - t) * (eq + 1) / 2 * f;
            }
            Console.WriteLine(f.ToString("F3"));

            Main(args);
        }
    }
}
