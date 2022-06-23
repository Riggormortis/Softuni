using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] water = Console.ReadLine()
                .Split(" ")
                .Select(double.Parse)
                .ToArray();

            double[] flour = Console.ReadLine()
                .Split(" ")
                .Select(double.Parse)
                .ToArray();

            //steel - from the first to the last => queue - FIFO
            Queue<double> queueWater = new Queue<double>(water);

            //carbon - from last to first => stack - LIFO
            Stack<double> stackFlour = new Stack<double>(flour);


            SortedDictionary<string, int> bakery = new SortedDictionary<string, int> {
                {"Croissant", 0 },
                {"Muffin", 0 },
                {"Baguette", 0 },
                {"Bagel", 0 },
                
            };


            while (queueWater.Count > 0 && stackFlour.Count > 0)
            {
                double currentWater = queueWater.Peek();
                double currentFlour = stackFlour.Peek();

                double sumBoth = currentWater + currentFlour;

                double percentageWater = (currentWater * 100) / sumBoth;

                if (percentageWater == 20 )
                {
                    bakery["Bagel"]++;
                    queueWater.Dequeue();
                    stackFlour.Pop();
                }
                else if (percentageWater == 30)
                {
                    bakery["Baguette"]++;
                    queueWater.Dequeue();
                    stackFlour.Pop();
                }
                else if (percentageWater == 40)
                {
                    bakery["Muffin"]++;
                    queueWater.Dequeue();
                    stackFlour.Pop();
                }
                else if (percentageWater == 50)
                {
                    bakery["Croissant"]++;
                    queueWater.Dequeue();
                    stackFlour.Pop();
                }
                else
                {
                    var flourReduced = currentFlour - currentWater;
                    queueWater.Dequeue();
                    stackFlour.Pop();
                    bakery["Croissant"]++;
                    stackFlour.Push(flourReduced);
                }

            }

            foreach (var bakedGood in bakery.OrderByDescending(x => x.Value).ThenBy(x => x.Key)) //sort alphabeticaly
            {
                //sword item -> key: swordName, value: swordCount

                if (bakedGood.Value > 0)
                {
                    Console.WriteLine($"{bakedGood.Key}: {bakedGood.Value}");
                }
            }
            if (queueWater.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine("Water left: " + String.Join(", ", queueWater));
            }
            if (stackFlour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine("Flour left: " + String.Join(", ", stackFlour));
            }


        }
    }
}
