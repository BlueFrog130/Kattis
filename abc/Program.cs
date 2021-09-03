using System;
using System.Collections.Generic;
using System.Linq;

namespace abc
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToList();

            nums.Sort();

            Dictionary<char, int> letters = new Dictionary<char, int>
            {
                { 'A', nums[0] },
                { 'B', nums[1] },
                { 'C', nums[2] }
            };


            Console.WriteLine(string.Join(' ', Console.ReadLine().ToCharArray().Select(c => letters[c])));
        }
    }
}
