using System;
using System.Linq;

namespace Lamps
{
    /// <summary>
    /// https://open.kattis.com/problems/lamps
    /// </summary>
    class Program
    {
        static Lamp incandescent = new Lamp
        {
            Power = 60,
            Life = 1000,
            Price = 5
        };

        static Lamp lowEnergy = new Lamp
        {
            Power = 11,
            Life = 8000,
            Price = 60
        };

        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int h = input[0];
            int p = input[1];
            int day = 0;
            while (incandescent <= lowEnergy)
            {
                day++;
                incandescent.DayPrice(day, h, p);
                lowEnergy.DayPrice(day, h, p);
            }
            Console.WriteLine(day);
        }

        struct Lamp
        {
            public int Power;
            public int Life;
            public int Price;
            public double Total;

            private double CalculatePrice(int h, int p)
            {
                double electricityCost = (Power * h * p) / 100000.0;
                int bulbCost = (((h - 1) / Life) + 1) * Price;
                return electricityCost + bulbCost;
            }

            public double DayPrice(int d, int h, int p) => Total = CalculatePrice(h * d, p);

            public static bool operator >(Lamp lamp1, Lamp lamp2) => lamp1.Total > lamp2.Total;
            public static bool operator <(Lamp lamp1, Lamp lamp2) => lamp1.Total < lamp2.Total;
            public static bool operator >=(Lamp lamp1, Lamp lamp2) => lamp1.Total >= lamp2.Total;
            public static bool operator <=(Lamp lamp1, Lamp lamp2) => lamp1.Total <= lamp2.Total;
        }
    }
}
