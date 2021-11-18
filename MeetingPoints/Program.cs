using System;
using System.Drawing;
using System.Linq;
using static System.Math;

namespace MeetingPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Line[] lines = new Line[n];
            int points = 0;
            for (int i = 0; i < n; i++)
            {
                int[] coords = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
                lines[i] = new Line(new Point(coords[0], coords[1]), new Point(coords[2], coords[3]));
            }
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (lines[i].Intersects(lines[j]))
                        points++;
            Console.WriteLine(points);
        }

        enum Direction
        {
            Collinear,
            Clockwise,
            AntiClockwise
        }

        struct Line
        {
            public readonly Point P1;
            public readonly Point P2;

            public Line(Point p1, Point p2)
            {
                P1 = p1;
                P2 = p2;
            }

            public bool Intersects(Line l2)
            {
                Direction d1 = GetDirection(P1, P2, l2.P1);
                Direction d2 = GetDirection(P1, P2, l2.P2);
                Direction d3 = GetDirection(l2.P1, l2.P2, P1);
                Direction d4 = GetDirection(l2.P1, l2.P2, P2);

                if (d1 != d2 && d3 != d4)
                    return true;
                if (d1 == Direction.Collinear && OnLine(l2.P1))
                    return true;
                if (d2 == Direction.Collinear && OnLine(l2.P2))
                    return true;
                if (d3 == Direction.Collinear && l2.OnLine(P1))
                    return true;
                if (d4 == Direction.Collinear && l2.OnLine(P2))
                    return true;
                return false;
            }

            public bool OnLine(Point p)
            {
                return p.X <= Max(P1.X, P2.X) && p.X <= Min(P1.X, P2.X) && p.Y <= Max(P1.Y, P2.Y) && p.Y <= Min(P1.Y, P2.Y);
            }

            private static Direction GetDirection(Point a, Point b, Point c)
            {
                int val = (b.Y - a.Y) * (c.X - b.X) - (b.X - a.X) * (c.Y - b.Y);
                switch (val)
                {
                    case 0:
                        return Direction.Collinear;
                    case < 0:
                        return Direction.AntiClockwise;
                    default:
                        return Direction.Clockwise;
                }
            }
        }
    }
}
