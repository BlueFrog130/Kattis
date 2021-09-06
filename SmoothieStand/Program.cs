using System;
using System.Collections.Generic;
using System.Linq;

namespace SmoothieStand
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(s => int.Parse(s)).ToArray();
            int k = nums[0];
            int r = nums[1];

            int[] ingredients = Console.ReadLine().Split(" ").Select(s => int.Parse(s)).ToArray();

            Recipe[] recipes = new Recipe[r];
            for (int i = 0; i < r; i++)
            {
                int[] line = Console.ReadLine().Split(" ").Select(s => int.Parse(s)).ToArray();
                recipes[i] = new Recipe(line.Take(k), line.Last());
            }

            int best = recipes.Select(x => x.Revenue(ingredients)).Max();

            Console.WriteLine(best);
        }
    }

    struct Recipe
    {
        public IEnumerable<int> NeededIngredients { get; }

        public int Price { get; }

        public Recipe(IEnumerable<int> ingredients, int price)
        {
            NeededIngredients = ingredients;
            Price = price;
        }

        public int Revenue(int[] ingredients)
        {
            return NeededIngredients.Select((n, i) => n == 0 ? int.MaxValue : ingredients[i] / n).Min() * Price;
        }
    }
}
