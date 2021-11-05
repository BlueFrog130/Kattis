using System;
using System.Linq;

namespace GrazedGrains
{
    class Program
    {
        /// <summary>
        /// https://open.kattis.com/problems/grazedgrains
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            Circle[] circles = new Circle[n];
            for (int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
                circles[i] = new Circle(line[0], line[1], line[2]);
            }
            double minX = circles.Min(c => c.X - c.Radius);
            double minY = circles.Min(c => c.Y - c.Radius);
            double maxX = circles.Max(c => c.X + c.Radius);
            double maxY = circles.Max(c => c.Y + c.Radius);

            double sr = 0.01;
            Circle sc = new Circle(0, 0, sr);
            double a = Math.PI * sr * sr;
            double error = Math.Pow(2 * sr, 2) - a;
            for (double y = minY + sr; y <= maxY - sr; y += sr * 2)
            {
                sc.Y = y;
                for (double x = minX + sr; x <= maxX - sr; x += sr * 2)
                {
                    sc.X = x;
                    if (circles.Any(c => c.Contains(sc)))
                    {
                        sum += a + error;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }

    struct Circle
    {
        public double X;
        public double Y;
        public double Radius;
        public double Area => Math.PI * Radius * Radius;
        public Circle(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public double Distance(Circle circle)
        {
            return Math.Sqrt((Math.Pow(circle.X - X, 2)) + (Math.Pow(circle.Y - Y, 2)));
        }

        public bool Contains(Circle circle)
        {
            double distance = Distance(circle);
            return distance <= Radius - circle.Radius;
        }
    }
}
