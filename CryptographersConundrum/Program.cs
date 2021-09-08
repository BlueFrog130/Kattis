using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptographersConundrum
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string target = GenPer(line.Length);
            int diff = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != target[i])
                    diff++;
            }
            Console.WriteLine(diff);
        }

        static string GenPer(int len)
        {
            string per = "PER";
            string ret = "";
            for (int i = 0; i < len / 3; i++)
            {
                ret += per;
            }
            return ret;
        }
    }
}
