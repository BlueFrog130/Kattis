using System;
using System.Collections.Generic;
using System.Linq;

namespace ConquestCampaign
{
    class Program
    {
        enum State
        {
            Unvisited,
            Current,
            Past
        }

        static int[] X_VECTOR = new int[] { -1, 1, 0, 0 };
        static int[] Y_VECTOR = new int[] { 0, 0, -1 ,1 };

        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            State[,] board = new State[input[0], input[1]];
            
            for (int i = 0; i < input[2]; i++)
            {
                int[] line = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
                board[line[0] - 1, line[1] - 1] = State.Current;
            }

            bool done = false;
            int days = 0;
            while (!done)
            {
                days++;
                done = true;
                foreach (State s in board)
                {
                    if (s == State.Unvisited)
                    {
                        done = false;
                        break;
                    }
                }

                if (done)
                    break;

                List<Tuple<int, int>> currents = new List<Tuple<int, int>>();

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == State.Current)
                        {
                            board[i, j] = State.Past;
                            currents.Add(new Tuple<int, int>(i, j));
                        }
                    }
                }

                foreach (Tuple<int, int> c in currents)
                {
                    var neighbors = Neighbors(ref board, c.Item1, c.Item2);
                    foreach (var n in neighbors)
                    {
                        board[n.Item1, n.Item2] = State.Current;
                    }
                }
            }

            Console.WriteLine(days);
        }

        static IEnumerable<Tuple<int, int>> Neighbors(ref State[,] board, int x, int y)
        {
            List<Tuple<int, int>> neighbors = new List<Tuple<int, int>>();

            for (int i = 0; i < 4; i++)
            {
                int nX = x + X_VECTOR[i];
                int nY = y + Y_VECTOR[i];

                if (nX < 0 || nY < 0 || nX >= board.GetLength(0) || nY >= board.GetLength(1) || board[nX, nY] != State.Unvisited)
                    continue;

                neighbors.Add(new Tuple<int, int>(nX, nY));
            }

            return neighbors;
        }
    }
}
