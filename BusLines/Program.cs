using System;
using System.Collections.Generic;
using System.Linq;

namespace BusLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(' ');
            int n = int.Parse(line[0]);
            int m = int.Parse(line[1]);


        }
    }

    class Network
    {
        private readonly ICollection<Station> stations;

    }

    class Station
    {
        public int Endpont { get; }
        public int Id => lines.Sum(l => l.Endpont);
        private readonly ICollection<Station> lines;
        public Station(int x)
        {
            Endpont = x;
            lines = new List<Station>();
        }
    }

    class Line
    {
        public Station From { get; set; }
        public Station To { get; set; }
    }
}
