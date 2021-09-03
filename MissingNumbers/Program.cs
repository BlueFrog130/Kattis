using System;
using System.Collections.Generic;
using System.Linq;

namespace MissingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();

            for (int i = 0; i < n; i++)
            {
                nums.Add(int.Parse(Console.ReadLine()));
            }

            IEnumerable<int> expected = Enumerable.Range(1, nums.Max());

            IEnumerable<int> difference = expected.Except(nums);

            if (!difference.Any())
            {
                Console.WriteLine("good job");
                return;
            }

            foreach (int d in difference)
            {
                Console.WriteLine(d);
            }
        }
    }
}
