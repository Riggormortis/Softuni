using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            //task - from last to first => stack - LIFO
            int[] task = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            //threads - from the first to the last => queue - FIFO
            int[] threads = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int taskToKill = int.Parse(Console.ReadLine());
                        
            Stack<int> stackTask = new Stack<int>(task);
                        
            Queue<int> queueThread = new Queue<int>(threads);

            while (true)
            {
                int currentThread = queueThread.Peek();
                int currentTask = stackTask.Peek();

                if (currentTask == taskToKill)
                {
                    break;
                }

                if (currentThread >= currentTask)
                {
                    queueThread.Dequeue();
                    stackTask.Pop();
                }
                else if (currentThread < currentTask)
                {
                    queueThread.Dequeue();
                }


            }

            Console.WriteLine($"Thread with value {queueThread.Peek()} killed task {taskToKill}");
            Console.WriteLine(string.Join(" ", queueThread));


        }
    }
}
