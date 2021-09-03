using System;
using System.Collections.Generic;

namespace LongestDistinctSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 5, 2, 111, 2, 4, 99, 9, 2, 5, 17, 99 };
            Console.WriteLine(Longest(nums));
        }

        static int Longest(int[] b)
        {
            int longest = 0;
            int n = b.Length;
            for (int i = 0; i < n; i++)
            {
                HashSet<int> hashSet = new HashSet<int>();
                for (int j = i; j < n; j++)
                {
                    int value = b[j];
                    bool successful = hashSet.Add(value);
                    if (!successful)
                    {
                        int seq = j - i;
                        if (seq > longest)
                        {
                            longest = seq;
                        }
                        break;
                    }
                }
            }
            return longest;
        }
    }
}
