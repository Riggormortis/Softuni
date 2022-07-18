using System;
using System.Linq;

namespace SumOfIntegers
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split(" ").ToArray();
            
           

                long num;

                int sum = 0;


                foreach (var item in elements)
                {
                    if (!long.TryParse(item, out num))
                    {
                        Console.WriteLine($"The element '{item}' is in wrong format!");
                    }
                    else if (long.Parse(item) >= 2147483647 || long.Parse(item) <= -2147483647)
                    {
                        Console.WriteLine($"The element '{item}' is out of range!");
                    }
                    else
                    {
                        int number = int.Parse(item);
                        sum += number;
                    }
                    
                    Console.WriteLine($"Element '{item}' processed - current sum: {sum}");

                }

                Console.WriteLine($"The total sum of all integers is: {sum}");
            
            

        }
    }



}
