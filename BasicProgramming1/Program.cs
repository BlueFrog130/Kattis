using System;
using System.Linq;

namespace BasicProgramming1
{
    class Program
    {
        enum Command
        {
            Print7 = 1,
            BiggerOrSmaller,
            Median,
            Sum,
            EvenSum,
            Mod26,
            LastThing
        }

        static void Main(string[] args)
        {
            uint[] line1 = Console.ReadLine().Split(' ').Select(x => uint.Parse(x)).ToArray();
            uint n = line1[0];
            Command t = (Command) line1[1];

            uint[] a = Console.ReadLine().Split(' ').Select(x => uint.Parse(x)).ToArray();

            switch (t)
            {
                case Command.Print7:
                    Console.WriteLine("7");
                    break;
                case Command.BiggerOrSmaller:
                    if (a[0] > a[1])
                        Console.WriteLine("Bigger");
                    else if (a[0] == a[1])
                        Console.WriteLine("Equal");
                    else
                        Console.WriteLine("Smaller");
                    break;
                case Command.Median:
                    Console.WriteLine(a.Take(3).OrderBy(x => x).ElementAt(1));
                    break;
                case Command.Sum:
                    Console.WriteLine(a.Sum(x => x));
                    break;
                case Command.EvenSum:
                    Console.WriteLine(a.Where(x => x % 2 == 0).Sum(x => x));
                    break;
                case Command.Mod26:
                    Console.WriteLine(a.Select(x => x % 26).Select(x => (char)(x + 97)).ToArray());
                    break;
                case Command.LastThing:
                    uint i = 0;
                    uint iter = 0;
                    while (iter <= n + 1)
                    {
                        iter++;
                        i = a[i];
                        if (i < 0 || i >= n)
                        {
                            Console.WriteLine("Out");
                            break;
                        }
                        else if (i == n - 1)
                        {
                            Console.WriteLine("Done");
                            break;
                        }
                        else if (iter == n)
                        {
                            Console.WriteLine("Cyclic");
                            break;
                        }
                    }
                    break;
            }
        }
    }
}
