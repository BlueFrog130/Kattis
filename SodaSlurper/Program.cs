using System;
using System.Collections.Generic;
using System.Linq;

namespace SodaSlurper
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> nums = Console.ReadLine().Split(' ').Select(s => int.Parse(s));
            // e
            int has = nums.ElementAt(0);
            // f
            int found = nums.ElementAt(1);
            // c
            int cost = nums.ElementAt(2);

            int drank = 0;
            int bottles = has + found;
            while (bottles >= cost)
            {
                bottles -= cost;
                drank++;
                bottles++;
            }
            Console.WriteLine(drank);
        }
    }
}
