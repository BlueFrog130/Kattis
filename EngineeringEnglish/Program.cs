using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace EngineeringEnglish
{
    /// <summary>
    /// https://open.kattis.com/problems/engineeringenglish
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> lines = new List<string[]>();
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                lines.Add(line.Split(" "));
            }
            IEqualityComparer<string> comparer = new CaseInsensitiveComparer();
            Dictionary<string, bool> used = new Dictionary<string, bool>(lines.SelectMany(l => l.Select(w => w)).Distinct(comparer).Select(w => new KeyValuePair<string, bool>(w, false)), comparer);
            foreach (string[] l in lines)
            {
                string output = "";
                foreach (string word in l)
                {
                    if (used[word])
                    {
                        output += ". ";
                    }
                    else
                    {
                        output += word + " ";
                        used[word] = true;
                    }
                }
                Console.WriteLine(output.Trim());
            }
        }
    }

    class CaseInsensitiveComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.ToLower() == y.ToLower();
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return obj.ToLower().GetHashCode();
        }
    }
}
