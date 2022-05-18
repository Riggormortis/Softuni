using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine()
                .Split();

            Queue<string> queue = new Queue<string>(people);
            int tossCountToRemove = int.Parse(Console.ReadLine());
            int currTosses = 1;
            while (queue.Count > 1)
            {
                var kidWithPotato = queue.Dequeue();
                if (currTosses != tossCountToRemove)
                {
                    currTosses++;
                    queue.Enqueue(kidWithPotato);
                }
                else
                {
                    currTosses = 1;
                    Console.WriteLine($"Removed {kidWithPotato}");
                }

                
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
