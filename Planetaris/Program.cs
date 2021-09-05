using System;
using System.Collections.Generic;
using System.Linq;

namespace Planetaris
{
    /// <summary>
    /// Planetarieas problem... First to complete in C#... Nice
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<long> nums = Console.ReadLine().Split(" ").Select(n => long.Parse(n)).ToList();
            long a = nums[0];
            long b = nums[1];

            // Straight up crashes for massive lines. Needed to create a sketchy "NextInt()"
            // List<long> ships = Console.ReadLine().Split(" ", StringSplitOptions.None).Select(n => long.Parse(n)).ToList();

            List<int> ships = new List<int>(100000);

            for (int i = 0; i < a; i++)
            {
                ships.Add(NextInt());
            }
            ships.Sort();

            int count = 0;
            foreach(int i in ships)
            {
                if (b > i)
                {
                    count++;
                    b -= (i + 1);
                }
                else if (b <= 0)
                {
                    break;
                }
            }
            Console.WriteLine(count);
        }

        /// <summary>
        /// Gets next integer from Console until a space or newline is hit
        /// </summary>
        /// <returns></returns>
        static int NextInt()
        {
            List<char> chars = new List<char>();
            char c;
            while ((c = (char)Console.Read()) != ' ' && c != '\n')
            {
                chars.Add(c);
            }
            return int.Parse(chars.ToArray());
        }
    }
}
