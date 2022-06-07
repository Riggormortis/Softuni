using System;
using System.Collections.Generic;
using System.Linq;
namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int startNumber = nums[0];
            int endNumber = nums[1];

            List<int> numbers = new List<int>();

            for (int number = startNumber; number <= endNumber; number++)
            {
                numbers.Add(number);
            }
            
            //"odd" or "even"
            string type = Console.ReadLine();

            Predicate<int> isEven = number => number % 2 == 0; 
            // true => number is even
            //false => number is false

            if (type == "even")
            {
                foreach (int number in numbers)
                {
                    if (isEven(number))
                    {
                        Console.Write(number + " ");
                    }
                }
            }
            else if (type == "odd")
            {
                foreach (int number in numbers)
                {
                    if (!isEven(number))
                    {
                        Console.Write(number + " ");
                    }
                }
            }
         }
    }
}
