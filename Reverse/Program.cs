using System;

namespace Reverse
{
    /// <summary>
    /// https://open.kattis.com/contests/jwkx6j/problems/ofugsnuid
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[100000];
            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            for (int i = n - 1; i >= 0; i--)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}