using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Tri
{
    /// <summary>
    /// https://open.kattis.com/contests/odnirc/problems/tri
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            Operator op = GetOperator(input[0], input[1], input[2]);
            if (op == Operator.None)
            {
                op = GetOperator(input[1], input[2], input[0]);
                Console.WriteLine($"{input[0]}={input[1]}{GetSymbol(op)}{input[2]}");
            }
            else
                Console.WriteLine($"{input[0]}{GetSymbol(op)}{input[1]}={input[2]}");
        }

        static Operator GetOperator(int a, int b, int c)
        {
            if (a + b == c) return Operator.Add;
            else if (a - b == c) return Operator.Subtract;
            else if (a * b == c) return Operator.Multiply;
            else if (a / b == c) return Operator.Divide;
            return Operator.None;
        }

        static string GetSymbol(Operator op)
        {
            FieldInfo fieldInfo = op.GetType().GetField(op.ToString());
            DescriptionAttribute description = (DescriptionAttribute)fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).First();
            return description.Description;
        }

        enum Operator
        {
            None,
            [Description("+")]
            Add,
            [Description("-")]
            Subtract,
            [Description("*")]
            Multiply,
            [Description("/")]
            Divide,
        }
    }
}
