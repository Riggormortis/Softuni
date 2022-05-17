using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                var splittedcmd = command.Split();
                if (splittedcmd[0] == "add")
                {
                    int first = int.Parse(splittedcmd[1]);
                    int second = int.Parse(splittedcmd[2]);

                    stack.Push(first);
                    stack.Push(second);
                }
                else if (splittedcmd[0] == "remove")
                {
                    int count = int.Parse(splittedcmd[1]);
                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToLower();
            }

            int sum = 0;
            while (stack.Count>0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");

        }
    }
}
