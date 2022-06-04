using System;
using System.Linq;
using System.Collections.Generic;
namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 1.20)
                .ToList();



            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }

        }
    }
}
