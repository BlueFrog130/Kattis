using System;
using System.Linq;

namespace Apaxiaaaaaaaaaaaans
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine().ToCharArray().Aggregate("", (str, c) => str.Length > 0 && str.Last() == c ? str : str + c));
        }
    }
}
