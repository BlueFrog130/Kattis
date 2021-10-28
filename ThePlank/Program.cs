using System;

namespace ThePlank
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sums = new int[n + 1];
            sums[0] = 1;
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= 3; j++)
                    if (i >= j)
                        sums[i] += sums[i - j];
            Console.WriteLine(sums[n]);
        }
    }
}
