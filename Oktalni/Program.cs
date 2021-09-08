using System;
using System.Text;

namespace Oktalni
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder binary = new StringBuilder(Console.ReadLine());

            while (binary.Length % 3 != 0)
            {
                binary.Insert(0, 0);
            }

            for (int i = 0; i < binary.Length; i += 3)
            {
                int n = 0;
                if (binary[i] == '1')
                {
                    n += 4;
                }
                if (binary[i+1] == '1')
                {
                    n += 2;
                }
                if (binary[i + 2] == '1')
                {
                    n += 1;
                }
                Console.Write(n);
            }
        }
    }
}
