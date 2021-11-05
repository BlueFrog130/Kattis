using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace _2048
{
    static class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(Console.ReadKey().Key);
            }
        }

        public static Point Vector(this Direction direction)
        {
            return direction switch
            {
                Direction.UP => new Point(0, -1),
                Direction.DOWN => new Point(0, 1),
                Direction.LEFT => new Point(-1, 0),
                Direction.RIGHT => new Point(1, 0),
                _ => Point.Empty,
            };
        }
    }

    class Board
    {
        private int[,] state;
        private Random random = new Random();

        public Board(int size = 4)
        {
            state = new int[size, size];
        }

        public IEnumerable<Point> EmptySpaces()
        {
            List<Point> empty = new List<Point>();
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(0); j++)
                {
                    if (state[i, j] == 0)
                    {
                        empty.Add(new Point(i, j));
                    }
                }
            }
            return empty;
        }

        public void AddSquare()
        {
            IEnumerable<Point> possible = EmptySpaces();
            Point rand = possible.ElementAt(random.Next(0, possible.Count()));
            state[rand.X, rand.Y] = 2;
        }

        public void Move(Direction direction)
        {
            // Keep shifting in that direction until none behind

        }

        public void Shift((int, int) coord, Direction direction)
        {
            var (x, y) = coord;
            
        }
    }

    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
}
