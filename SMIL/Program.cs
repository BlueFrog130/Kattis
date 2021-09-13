using System;
using System.Collections.Generic;
using System.Linq;

namespace SMIL
{
    /// <summary>
    /// https://open.kattis.com/contests/jwkx6j/problems/smil
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int idx = 0;
            IEnumerable<string> smilies = new string[] { ":)", ";)", ":-)", ";-)" };
            while (true)
            {
                var indicies = smilies.Select(s => line.IndexOf(s, idx)).Where(s => s > -1);
                if (!indicies.Any())
                    break;
                else
                {
                    idx = indicies.Min();
                    Console.WriteLine(idx);
                }

                idx++;
            }
        }
    }
}
