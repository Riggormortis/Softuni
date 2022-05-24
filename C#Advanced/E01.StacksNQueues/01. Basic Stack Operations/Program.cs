using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()    //"5 2 13"
                            .Split(' ')           //["5", "2", "13"]
                            .Select(x => int.Parse(x)) //[5, 2, 13]
                            .ToArray();
            int n = numbers[0];
            int s = numbers[1];
            int x = numbers[2];

            List<int> numbersList = Console.ReadLine() // "1 13 45 32 4"
                                    .Split(' ')        //["1", "13", "45", "32", "4"]
                                    .Select(x => int.Parse(x)) //[1, 13, 45, 32, 4]
                                    .ToList();          // {1, 13, 45, 32, 4}

            Stack<int> stack = new Stack<int>(); //нов празен стек

            //N -> броят на елементите push
            for (int i = 0; i < n; i++)
            {
                stack.Push(numbersList[i]);
            }

            //S -> броят на елементите pop
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            //X -> потърсим в стек
            if (stack.Count == 0) //празен стек 
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min()); //най-малкия елемент в стека
            }

        }
    }
}
