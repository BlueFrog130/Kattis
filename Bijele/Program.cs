using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bijele
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            IList<int> nums = line.Split(' ').Select(n => int.Parse(n)).ToList();
            int[] correct = { 1, 1, 2, 2, 2, 8 };
            Parallel.For(0, nums.Count, i =>
            {
                nums[i] = correct[i] - nums[i];
            });
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
