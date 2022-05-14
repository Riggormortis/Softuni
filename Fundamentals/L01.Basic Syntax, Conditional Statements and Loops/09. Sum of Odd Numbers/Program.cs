using System;

namespace _09._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < number; i++)
            {
                int currentOdNumber = 1 + (i * 2);
                // 1 + (0 * 2) = 1
                // 1 + (1 * 2) = 3
                // 1 + (2 * 2) = 5
                sum += currentOdNumber;
                Console.WriteLine(currentOdNumber);
            }

            Console.WriteLine($"Sum: {sum}");

        }
    }
}
