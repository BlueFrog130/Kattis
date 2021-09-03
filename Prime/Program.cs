using System;

namespace Prime
{
    class Program
    {
        static bool IsPrime(int v)
        {
            if (v == 2) return true;
            if (v % 2 == 0) return false;

            for (int i = 3; i * i <= v; i += 2)
                if (v % i == 0)
                    return false;

            return true;
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int r = random.Next(2, 98);
                Console.WriteLine($"Is {r} prime? {IsPrime(r)}");
            }
        }
    }
}
