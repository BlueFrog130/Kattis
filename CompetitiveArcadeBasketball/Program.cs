using System;
using System.Collections.Generic;
using System.Linq;

namespace CompetitiveArcadeBasketball
{
    /// <summary>
    /// https://open.kattis.com/problems/competitivearcadebasketball
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            Dictionary<string, Player> players = Enumerable.Range(0, input[0]).Select(i => new Player(Console.ReadLine(), input[1])).ToDictionary(p => p.Name);
            bool someOneWon = false;
            for (int i = 0; i < input[2]; i++)
            {
                string[] line = Console.ReadLine().Split(" ");
                if (players[line[0]].AddScore(int.Parse(line[1])))
                    someOneWon = true;
            }
             if (!someOneWon)
                Console.WriteLine("No winner!");
        }
    }

    class Player
    {
        public readonly string Name;
        
        private readonly int p;
        private int score;

        public Player(string name, int p)
        {
            Name = name;
            score = 0;
            this.p = p;
        }
        public bool AddScore(int amt)
        {
            score += amt;
            if (score >= p && (score - amt) < p)
            {
                Console.WriteLine($"{Name} wins!");
                return true;
            }
            return false;
        }
    }
}
