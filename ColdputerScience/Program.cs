using System;
using System.Linq;

namespace ColdputerScience
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = Console.ReadLine();

            Console.WriteLine(Console.ReadLine().Split(' ').Select(n => int.Parse(n)).Where(n => n < 0).Count());
        }
    }
}
