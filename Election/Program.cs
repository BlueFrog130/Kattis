using System;
using System.Collections.Generic;
using System.Linq;

namespace Election
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Candidate> candidates = new Dictionary<string, Candidate>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                candidates.Add(name, new Candidate(name, Console.ReadLine()));
            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
                if (candidates.TryGetValue(Console.ReadLine(), out Candidate candidate))
                    candidate.Votes++;
            Candidate winner = candidates.Values.Aggregate((a, b) => a.Votes > b.Votes ? a : b);
            if (candidates.Values.Count(c => c.Votes == winner.Votes) > 1)
                Console.WriteLine("tie");
            else
                Console.WriteLine(winner.Party);
        }

        class Candidate
        {
            public readonly string Name;
            public readonly string Party;
            public int Votes;
            public Candidate(string name, string party)
            {
                Name = name;
                Party = party;
                Votes = 0;
            }
        }
    }
}
