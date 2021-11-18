using System;
using System.Collections.Generic;
using System.Linq;

namespace Election
{
    /// <summary>
    /// https://open.kattis.com/problems/election2
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> candidateParities = Enumerable.Range(0, n)
                .Select(i => Tuple.Create(Console.ReadLine(), Console.ReadLine()))
                .ToDictionary(k => k.Item1, v =>v.Item2.Equals("independent") ? Guid.NewGuid().ToString() : v.Item2);
            Dictionary<string, int> partyVotes = candidateParities.Values.ToDictionary(k => k, v => 0);
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                candidateParities.TryGetValue(Console.ReadLine(), out string party);
                if (string.IsNullOrEmpty(party))
                    continue;
                partyVotes[party]++;
            }
            int max = partyVotes.Values.Max();
            int winnerCount = partyVotes.Values.Count(v => v == max);
            if (winnerCount > 1)
                Console.WriteLine("tie");
            else
            {
                string winner = partyVotes.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
                if (Guid.TryParse(winner, out Guid guid))
                    Console.WriteLine("independnet");
                else
                    Console.WriteLine(winner);
            }
        }
    }
}
