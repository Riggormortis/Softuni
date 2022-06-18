using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            // hats - stack
            //scarfs - queue
            int[] inputHats = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] inputScarfs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            Stack<int> hats = new Stack<int>(inputHats);
            Queue<int> scarfs = new Queue<int>(inputScarfs);

            List<int> elements = new List<int>();

            //while elements.any
            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();
                //if (hats > scarfs) 
                //-> net set -> hats + scarft
                //remove hats and scarfs element
                if (hat > scarf)
                {
                    elements.Add(hat + scarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                //else if (scarfs > hats)
                // remove hat
                else if (scarf > hat)
                {
                    hats.Pop();
                }
                //else
                //remove scarf
                // element of hats + 1
                else
                {
                    scarfs.Dequeue();
                    int value = hats.Pop() + 1;
                    hats.Push(value);
                }
               
            }

            Console.WriteLine($"The most expensive set is: {elements.Max()}");
            Console.WriteLine(string.Join(" ", elements));

        }
    }
}
