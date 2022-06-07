using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            List<int> numbers = new List<int>(); //all the numbers from 1 to n

            for (int number = 1; number <= n; number++)
            {
                numbers.Add(number);
            }

            List<int> printNumbers = new List<int>();

            foreach (int number in numbers)
            {
                bool isDivisible = true;
                foreach (int divider in dividers)
                {
                    Predicate<int> divisible = number => number % divider == 0;

                    if (!divisible(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }


                if (isDivisible)
                {
                    printNumbers.Add(number);
                }
            }

            Console.WriteLine(String.Join(" ", printNumbers));

        }
    }
}
