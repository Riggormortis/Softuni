using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> integers = new Stack<int>();


            for (int i = 0; i < n; i++)
            {
                int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (commands[0] == 1)
                {
                    integers.Push(commands[1]);
                }
                else if (commands[0] == 2 && integers.Any())
                {
                    integers.Pop();
                }
                else if (commands[0] == 3 && integers.Any())
                {
                    Console.WriteLine(integers.Max());
                }
                else if (commands[0] == 4 && integers.Any())
                {
                    Console.WriteLine(integers.Min());
                }
            }


            Console.WriteLine(string.Join(", ", integers));


        }
    }
}