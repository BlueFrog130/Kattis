using System;

namespace BuildingPyramids
{
    /// <summary>
    /// https://open.kattis.com/problems/pyramids
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int blocks = int.Parse(Console.ReadLine());
            int levels = 0;
            int w = 1;
            while ((blocks - (int)Math.Pow(w, 2)) >= 0)
            {
                levels++;
                blocks -= (int)Math.Pow(w, 2);
                w += 2;
            }
            Console.WriteLine(levels);
        }
    }
}
