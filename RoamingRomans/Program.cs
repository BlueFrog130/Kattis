using System;

namespace RoamingRomans
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double ratio = 5280.0 / 4854.0;

            Console.WriteLine(Math.Round(x * 1000 * ratio));
        }
    }
}
