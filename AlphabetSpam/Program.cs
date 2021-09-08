using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AlphabetSpam
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Regex ws = new Regex(@"_", RegexOptions.Compiled);
            Regex lower = new Regex(@"[a-z]", RegexOptions.Compiled);
            Regex upper = new Regex(@"[A-Z]", RegexOptions.Compiled);
            int syms = line.Where(c => c < 65 || c > 122 || (c > 90 && c < 97) && c != 95).Count();

            Console.WriteLine((double)ws.Matches(line).Count / line.Length);
            Console.WriteLine((double)lower.Matches(line).Count / line.Length);
            Console.WriteLine((double)upper.Matches(line).Count / line.Length);
            Console.WriteLine((double)syms / line.Length);
        }
    }
}
