using System;
using System.Linq;

namespace JointJogJam
{
    /// <summary>
    /// https://open.kattis.com/problems/jointjogjam
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] points = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            Person kari = new Person(new Point(points[0], points[1]), new Point(points[4], points[5]));
            Person ola = new Person(new Point(points[2], points[3]), new Point(points[6], points[7]));
            double dStart = kari.Start.DistanceTo(ola.Start);
            double dEnd = kari.End.DistanceTo(ola.End);
            double longest = dStart > dEnd ? dStart : dEnd;
            Console.WriteLine(longest);
        }
    }

    struct Point
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point p) => Math.Sqrt(Math.Pow(p.X - X, 2) + Math.Pow(p.Y - Y, 2));
    }
    
    struct Person
    {
        public Point Start { get; }
        public Point End { get; }
        public Person(Point s, Point e)
        {
            Start = s;
            End = e;
        }
    }
}
