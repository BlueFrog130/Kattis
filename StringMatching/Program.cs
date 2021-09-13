using System;

namespace StringMatching
{
    /// <summary>
    /// https://open.kattis.com/problems/stringmatching
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string pattern;
            while (!string.IsNullOrEmpty(pattern = Console.ReadLine()))
            {
                string text = Console.ReadLine();
                int offset = 0;
                int i;
                while ((i = GetMatchedIndex(ref text, ref pattern, offset)) != -1)
                {
                    Console.Write($"{i} ");
                    offset = i + 1;
                }
                Console.WriteLine();
            }
        }

        static int GetMatchedIndex(ref string s, ref string pattern, int from)
        {
            string sub = s.Substring(from);
            int idx = sub.IndexOf(pattern);
            if (idx == -1)
                return -1;
            return idx + from;
        }
    }
}
