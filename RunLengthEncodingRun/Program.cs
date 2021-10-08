using System;
using System.Linq;

namespace RunLengthEncodingRun
{
    /// <summary>
    /// https://open.kattis.com/problems/runlengthencodingrun
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(" ");
            string output = "";
            switch (line[0])
            {
                case "E":
                    int idx = 0;
                    while (true)
                    {
                        if (idx >= line[1].Length)
                            break;
                        char c = line[1][idx];
                        int count = 1;
                        while (idx + count < line[1].Length && line[1][idx + count] == c)
                        {
                            count++;
                        }
                        output += string.Concat(c, count);
                        idx += count;
                    }
                    break;
                case "D":
                    for (int i = 0; i < line[1].Length; i += 2)
                    {
                        output += string.Join("", Enumerable.Range(0, int.Parse(line[1][i + 1].ToString())).Select(x => line[1][i]));
                    }
                    break;
            }
            Console.WriteLine(output);

        }
    }
}
