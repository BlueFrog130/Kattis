using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstOrchard
{
    /// <summary>
    /// https://open.kattis.com/problems/orchard
    /// </summary>
    class Program
    {
        const int GAMES = 1000000;
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int wins = 0;
            Parallel.For(0, GAMES, i =>
            {
                Orchard game = new Orchard(input);
                int turns = 0;
                while (!game.Turn())
                    turns++;
                if (game.Win)
                    wins++;
            });
            Console.WriteLine(wins / (double)GAMES);
        }
    }

    class Orchard
    {
        private Dictionary<string, int> basket;
        private int raven;
        private Random random = new Random();
        private readonly int diceLength;

        public bool Done => raven == 0 || basket.Values.All(v => v <= 0);
        public bool Lose => raven == 0;
        public bool Win => !Lose;

        public Orchard(string input)
        {
            int[] parsed = input.Split(" ").Select(x => int.Parse(x)).ToArray();
            basket = new Dictionary<string, int>();
            basket["red"] = parsed[0];
            basket["green"] = parsed[1];
            basket["blue"] = parsed[2];
            basket["yellow"] = parsed[3];
            raven = parsed[4];
            diceLength = Enum.GetValues(typeof(Dice)).Length;
        }

        public Dice Roll()
        {
            return (Dice)random.Next(0, diceLength);
        }

        public bool Turn()
        {
            Dice action = Roll();
            switch (action)
            {
                case Dice.Red:
                    basket["red"]--;
                    break;
                case Dice.Green:
                    basket["green"]--;
                    break;
                case Dice.Blue:
                    basket["blue"]--;
                    break;
                case Dice.Yellow:
                    basket["yellow"]--;
                    break;
                case Dice.Raven:
                    raven--;
                    break;
                case Dice.Basket:
                    basket[basket.Aggregate((a, b) => a.Value > b.Value ? a : b).Key]--;
                    break;
                default:
                    break;
            }
            return Done;
        }
    }

    enum Dice
    {
        Red,
        Green,
        Blue,
        Yellow,
        Raven,
        Basket
    }
}
