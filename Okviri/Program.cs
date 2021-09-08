using System;

namespace Okviri
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            Outer(ref line);
            Inner(ref line);

            for (int i = 0; i < line.Length; i++)
            {
                bool star = (i + 1) % 3 == 0 || (i > 0 && i % 3 == 0);
                if (star)
                    Console.Write($"*.{line[i]}.");
                else
                    Console.Write($"#.{line[i]}.");
            }

            if (line.Length % 3 == 0)
                Console.WriteLine("*");
            else
                Console.WriteLine("#");

            Inner(ref line);
            Outer(ref line);
        }

        static void Outer(ref string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                bool star = (i + 1) % 3 == 0;
                if (i == 0)
                    Console.Write(".");
                if (star)
                    Console.Write(".*.");
                else
                    Console.Write(".#.");
                Console.Write(".");
            }
            Console.WriteLine();
        }

        static void Inner(ref string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                bool star = (i + 1) % 3 == 0;
                if (star)
                    Console.Write(".*.*");
                else
                    Console.Write(".#.#");
            }
            Console.WriteLine(".");
        }
    }
}
