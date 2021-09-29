using System;

namespace LineThemUp
{
    /// <summary>
    /// https://open.kattis.com/problems/lineup
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool asc = true;
            bool desc = true;
            string prev = Console.ReadLine();
            for (int i = 1; i < n; i++)
            {
                string word = Console.ReadLine();
                int comp = word.CompareTo(prev);
                if (asc && comp < 0)
                    asc = false;
                if (desc && comp > 0)
                    desc = false;
                if (!asc && !desc)
                    break;
                prev = word;
            }
            if (asc)
                Console.WriteLine("INCREASING");
            else if (desc)
                Console.WriteLine("DECREASING");
            else
                Console.WriteLine("NEITHER");
        }
    }
}
