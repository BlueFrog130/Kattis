using System;

namespace Lektira
{
    /// <summary>
    /// INCOMPLETE
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int third = word.Length / 3;

            string p1 = word.Substring(0, third);
            string p2 = word.Substring(third, third);
            string p3 = word.Substring(2 * third, third);

            Console.WriteLine(p1 + p2 + p3);
        }
    }
}
