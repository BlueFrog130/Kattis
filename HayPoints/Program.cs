using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HayPoints
{
    /// <summary>
    /// https://open.kattis.com/problems/haypoints
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(x => int.Parse(x))
                .ToArray();
            
            Dictionary<string, int> terms = Enumerable.Range(0, input[0])
                .Select(x => Console.ReadLine().Split(" "))
                .ToDictionary(k => k[0], v => int.Parse(v[1]));
            
            for (int i = 0; i < input[1]; i++)
            {
                StringBuilder stringBuilder = new StringBuilder();
                string line;
                while ((line = Console.ReadLine()) != ".")
                    stringBuilder.AppendLine(line);
                Console.WriteLine(GetSalary(stringBuilder.ToString().Split(" "), terms));
            }
        }

        /// <summary>
        /// Too slow... need to fix
        /// </summary>
        /// <param name="line"></param>
        /// <param name="terms"></param>
        /// <returns></returns>
        static int GetSalary(string[] line, Dictionary<string, int> terms)
        {
            var vals = terms.Where(c => line.Contains(c.Key));
            return vals.Sum(v => v.Value);
        }
    }
}
