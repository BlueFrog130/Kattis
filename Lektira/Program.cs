using System;
using System.Linq;

namespace Lektira
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string best = word;

            for (int i = 1; i < word.Length - 1; i++)
            {
                for (int j = i + 1; j < word.Length; j++)
                {
                    Check(word, ref best, i, j);
                }
            }

            Console.WriteLine(best);
        }

        static void Check(string s, ref string best, int i, int j)
        {
            string p1 = new string(s.Substring(0, i).Reverse().ToArray());
            string p2 = new string(s.Substring(i, j - i).Reverse().ToArray());
            string p3 = new string(s.Substring(j).Reverse().ToArray());

            string reversed = string.Concat(p1, p2, p3);

            int compare = string.Compare(reversed, best);
            if (compare < 0)
                best = reversed;
        }
    }
}
