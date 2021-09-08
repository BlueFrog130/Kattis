using System;
using System.Linq;

namespace AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine().Split(' ').Select(x => int.Parse(x)).Sum());
        }
    }
}
