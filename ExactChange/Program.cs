using System;

namespace ExactChange
{
    /// <summary>
    /// https://open.kattis.com/problems/exactchange2
    /// </summary>
    class Program
    {
        // I hate myself
        static readonly int inf = 2 << 28;
        static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine());
            for (int c = 0; c < cases; c++)
            {
                int cost = int.Parse(Console.ReadLine());

                int[] v = new int[10001];
                Array.Fill(v, inf);
                v[0] = 0;

                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    int coin = int.Parse(Console.ReadLine());
                    for (int j = 10000 - coin; j >= 0; j--)
                    {
                        v[j + coin] = Math.Min(v[j + coin], v[j] + 1);
                    }
                }
                
                for (int i = cost; i <= 10000; i++)
                {
                    if (v[i] < inf/2)
                    {
                        Console.WriteLine($"{i} {v[i]}");
                        break;
                    }
                }
            }
        }
    }
}
