using System;
using System.Numerics;

namespace AnotherCandies
{
    /// <summary>
    /// https://open.kattis.com/contests/odnirc/problems/anothercandies
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine());
            for (int c = 0; c < cases; c++)
            {
                Console.ReadLine(); // case starts with empty line
                int students = int.Parse(Console.ReadLine());
                BigInteger sum = 0;
                for (int i = 0; i < students; i++)
                    sum += long.Parse(Console.ReadLine());
                bool even = sum % students == 0;
                if (even)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
    }
}
