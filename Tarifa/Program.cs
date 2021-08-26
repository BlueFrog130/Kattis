using System;

namespace Tarifa
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int megabytes = x;
            for (int i = 0; i < n; i++)
            {
                int used = int.Parse(Console.ReadLine());
                megabytes += x - used;
            }
            Console.WriteLine(megabytes);
        }
    }
}
