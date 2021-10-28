using System;
using System.Drawing;
using System.Linq;

namespace GrazedGrains
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Circle[] circles = new Circle[n];
            for (int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
                circles[i] = new Circle(line[0], line[1], line[2]); 
            }
            Console.WriteLine(sum);
        }
    }

    struct Circle
    {
        public Point Center;
        public int Radius;
        public Circle(int x, int y, int radius)
        {
            Center = new Point(x, y);
            Radius = radius;
        }
    }
}
