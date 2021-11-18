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

        public static bool IsVertical(this Direction direction) => (int)direction % 2 == 1;
        public static bool IsHorizontal(this Direction direction) => (int)direction % 2 == 0;
    }

    public class Board
    {
        private readonly int size;
        private readonly int[,] state;
        private readonly Random random = new Random();

        public Board(int size = 4)
        {
            this.size = size;
            state = new int[size, size];
        }

        public IEnumerable<Point> EmptySpaces()
        {
            List<Point> empty = new List<Point>();
            for (int i = 0; i < state.GetLength(0); i++)
                for (int j = 0; j < state.GetLength(0); j++)
                    if (state[i, j] == 0)
                        empty.Add(new Point(i, j));
            return empty;
        }

        public void FillRandom()
        {
            IEnumerable<Point> possible = EmptySpaces();
            Point rand = possible.ElementAt(random.Next(0, possible.Count()));
            state[rand.X, rand.Y] = 2;
        }

        public void Move(Direction direction)
        {
            // Keep shifting in that direction until none behind

        }

        private void Shift(Point coord, Direction direction)
        {
            for (int i = Edge(direction); i < size; i++)
            {
                for (int j = Edge(direction); j < size; j++)
                {

                }
            }
            
        }

        /// <summary>
        /// Swaps 2 points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        private void Swap(Point p1, Point p2)
        {
            int tmp = state[p1.X, p1.Y];
            state[p1.X, p1.Y] = state[p2.X, p2.Y];
            state[p2.X, p2.Y] = tmp;
        }

        /// <summary>
        /// Checks if this point is valid
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool IsValid(Point position)
        {
            return position.X >= 0 && position.Y >= 0 && position.X < state.Length && position.Y < state.Length && state[position.X, position.Y] == 0;
        }

        /// <summary>
        /// Gets opposite edge in the direction specified
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private int Edge(Direction direction)
        {
            return direction switch
            {
                Direction.LEFT or Direction.UP => 0,
                _ => size,
            };
        }
    }

    public enum Direction
    {
        UP = 1,
        LEFT,
        DOWN,
        RIGHT
    }
}
