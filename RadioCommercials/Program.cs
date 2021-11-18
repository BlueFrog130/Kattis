using System;
using System.Linq;

namespace RadioCommercials
{
    /// <summary>
    /// https://open.kattis.com/problems/commercials
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int price = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).Last();
            int[] listeners = Console.ReadLine().Split(" ").Select(x => int.Parse(x) - price).ToArray();
            Console.WriteLine(MaxSubSequence(ref listeners));
        }

        static int MaxSubSequence(ref int[] arr)
        {
            int maxSoFar = arr[0], maxEndingHere = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (maxEndingHere < 0)
                    maxEndingHere = arr[i];
                else
                    maxEndingHere += arr[i];

                if (maxEndingHere >= maxSoFar)
                    maxSoFar = maxEndingHere;
            }
            return maxSoFar;
        }
    }
}
