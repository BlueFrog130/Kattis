using System;

namespace JumboJavelin
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int len = 0;
            for (int i = 0; i < n; i++)
            {
                len += int.Parse(Console.ReadLine());
            }
            Console.WriteLine(len - n + 1);
        }
    }
}
