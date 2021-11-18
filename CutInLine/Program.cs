using System;
using System.Collections.Generic;
using System.Linq;

namespace CutInLine
{
    /// <summary>
    /// https://open.kattis.com/problems/cutinline
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> line = new List<string>(Enumerable.Range(0, n).Select(x => Console.ReadLine()));
            
            int c = int.Parse(Console.ReadLine());
            for (int i = 0; i < c; i++)
            {
                string[] command = Console.ReadLine().Split(' ');
                switch(command[0])
                {
                    case "cut":
                        line.Insert(line.IndexOf(command[2]), command[1]);
                        break;
                    case "leave":
                        line.Remove(command[1]);
                        break;
                }
            }
            Console.WriteLine(string.Join('\n', line));
        }
    }
}
