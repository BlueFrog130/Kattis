using System;
using System.Linq;

namespace Trik
{
    /// <summary>
    /// https://open.kattis.com/problems/trik
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            char[] moves = Console.ReadLine().ToCharArray();
            int[] position = new int[] { 1, 0, 0 };
            foreach (char move in moves)
            {
                switch (move)
                {
                    case 'A':
                        Swap(ref position, 0, 1);
                        break;
                    case 'B':
                        Swap(ref position, 1, 2);
                        break;
                    case 'C':
                        Swap(ref position, 0, 2);
                        break;
                }
            }
            Console.WriteLine(position.TakeWhile(x => x != 1).Count() + 1);
        }

        static void Swap(ref int[] position, int p1, int p2)
        {
            int buffer = position[p1];
            position[p1] = position[p2];
            position[p2] = buffer;
        }
    }
}
