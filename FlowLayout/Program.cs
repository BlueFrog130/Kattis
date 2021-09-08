using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowLayout
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());

            if (m == 0)
                return;

            List<Row> rows = new List<Row>{ new Row(m) };

            string line;
            while ((line = Console.ReadLine()) != "-1 -1")
            {
                Tile tile = new Tile(line.Split(' ').Select(x => int.Parse(x)).ToArray());
                Row row = rows.Last();
                if (row.Fits(tile))
                {
                    row.Add(tile);
                }
                else
                {
                    rows.Add(new Row(m, tile));
                }
            }

            Console.WriteLine($"{rows.Max(r => r.Width)} x {rows.Sum(r => r.Height)}");

            Main(args);
        }
    }

    class Row
    {
        private readonly List<Tile> tiles = new List<Tile>();

        private readonly int max;

        public int Height => tiles.Max(t => t.Height);

        public int Width => tiles.Sum(t => t.Width);

        public Row(int max)
        {
            this.max = max;
        }

        public Row(int max, Tile tile) : this(max)
        {
            tiles.Add(tile);
        }

        public bool Fits(Tile tile) => tile.Width + Width <= max;

        public void Add(Tile tile) => tiles.Add(tile);
    }

    struct Tile
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Tile(int[] nums)
        {
            Width = nums[0];
            Height = nums[1];
        }
    }
}
