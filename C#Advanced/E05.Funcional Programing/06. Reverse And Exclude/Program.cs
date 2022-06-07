using System;
using System.Collections.Generic;
using System.Linq;
namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            int n = int.Parse(Console.ReadLine());

            Predicate<int> toRemove = number => number % n == 0;

            List<int> newList = new List<int>();
            List<int> reversedNumbers = Enumerable.Reverse(newList).ToList();

            foreach (int number in numbers)
            {

                newList.Add(number);
                
            }

            

            Console.WriteLine(String.Join(" ", reversedNumbers));
        }
    }
}
