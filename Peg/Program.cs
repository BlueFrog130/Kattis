using System;

namespace Peg
{
    class Program
    {
        private static readonly char empty = '.';
        private static readonly char piece = 'o';
        private static readonly char space = ' ';

        static void Main(string[] args)
        {
            char[][] board = new char[7][];

            for (int i = 0; i < board.Length; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();
            }

            // search for '.' and get number of pegs 2 spaces away in each direction
            uint moves = 0;
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == empty)
                    {
                        // look 2 up, down, left, right for 'o'
                        if (row - 2 >= 0 &&
                            board[row - 2][col] == piece &&
                            board[row - 1][col] == piece)
                        {
                            moves++;
                        }
                        if (row + 2 < board.Length &&
                            board[row + 2][col] == piece &&
                            board[row + 1][col] == piece)
                        {
                            moves++;
                        }

                        if (col - 2 >= 0 &&
                            board[row][col - 2] == piece &&
                            board[row][col - 1] == piece)
                        {
                            moves++;
                        }

                        if (col + 2 < board[row].Length &&
                            board[row][col + 2] == piece &&
                            board[row][col + 1] == piece)
                        {
                            moves++;
                        }
                    }
                }
            }

            Console.WriteLine(moves);
        }
    }
}
