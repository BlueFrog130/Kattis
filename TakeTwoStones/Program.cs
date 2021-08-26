using System;

namespace TakeTwoStones
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n % 2 != 0)
                Console.WriteLine("Alice");
            else
                Console.WriteLine("Bob");
        }
    }
}
