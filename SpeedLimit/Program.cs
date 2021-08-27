using System;

namespace SpeedLimit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == -1)
                return;

            int miles = 0;
            int time = 0;

            for (int i = 0; i < n; i++)
            {
                string[] chunks = Console.ReadLine().Split(" ");
                int s = int.Parse(chunks[0]);
                int t = int.Parse(chunks[1]);
                miles += s * (t - time);
                time = t;
            }

            Console.WriteLine($"{miles} miles");

            Main(args);
        }
    }
}
