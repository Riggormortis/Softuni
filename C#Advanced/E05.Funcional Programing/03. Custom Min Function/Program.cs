using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            //gets list => returns smallest number in the list
            Func<List<int>, int> printMinElemet = list =>
            {
                int min = int.MaxValue;

                foreach (int number in list)
                {
                    if (number < min)
                    {
                        min = number;
                    }
                }

                return min;
            };

            printMinElemet(numbers);
        }
    }
}
