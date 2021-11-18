using System;
using System.Collections.Generic;
using System.Linq;

namespace Grading
{
    /// <summary>
    /// https://open.kattis.com/problems/grading
    /// </summary>
    class Program
    {
        enum Grade
        {
            A, B, C, D, E, F
        }
        static void Main(string[] args)
        {
            List<Scale> scale = Console.ReadLine()
                .Split(" ")
                .Select(x => int.Parse(x))
                .Select((x, i) => new Scale() { Score = x, Grade = (Grade)i })
                .ToList();
            scale.Add(new Scale() { Score = 0, Grade = Grade.F });
            int score = int.Parse(Console.ReadLine());
            Scale grade = scale.FirstOrDefault(s => s.Score <= score);

            Console.WriteLine(grade.Grade.ToString());
        }
        struct Scale
        {
            public Grade Grade;
            public int Score;
        }
    }
}
