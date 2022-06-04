using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();

            int[] sorted = numbers.OrderByDescending(n => n)
                .ToArray();

            if (sorted.Length >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{sorted[i]} ");
                }
            }
            else
            {
                for (int i = 0; i < sorted.Length; i++)
                {
                    Console.Write($"{sorted[i]} ");
                }
            }
            

        }
    }
}
