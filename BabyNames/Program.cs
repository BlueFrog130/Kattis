using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BabyNames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Baby> babies = new HashSet<Baby>();
            CommandType cmd;
            do
            {
                string line = Console.ReadLine();
                string[] parts = line.Split(' ', StringSplitOptions.None);
                cmd = (CommandType)int.Parse(parts[0]);
                switch (cmd)
                {
                    case CommandType.Add:
                        babies.Add(new Baby(parts[1], (GenderSuitability)int.Parse(parts[2])));
                        break;
                    case CommandType.Remove:
                        babies.RemoveWhere(b => b.BabyName == parts[1]);
                        break;
                    case CommandType.Query:
                        string start = parts[1];
                        string end = parts[2];
                        GenderSuitability gender = (GenderSuitability)int.Parse(parts[3]);
                        IEnumerable<int> range = Enumerable.Range(start, end - 1);
                        if (gender == GenderSuitability.Both)
                            Console.WriteLine(
                                babies.Count(b =>
                                    range.Any(c => b.BabyName.StartsWith((char)c))
                                )
                            );
                        else
                            Console.WriteLine(
                                babies.Count(b =>
                                    range.Any(c => b.BabyName.StartsWith((char)c)) && b.GenderSuitability == gender
                                )
                            );
                        break;
                }
            } while (cmd != CommandType.Stop);
        }
    }

    enum CommandType
    {
        Stop,
        Add,
        Remove,
        Query
    }

    enum GenderSuitability
    {
        Both,
        Male,
        Female
    }

    class Baby
    {
        public string BabyName { get; }
        public GenderSuitability GenderSuitability { get; }

        public Baby(string name, GenderSuitability gender)
        {
            BabyName = name;
            GenderSuitability = gender;
        }
    }
}
