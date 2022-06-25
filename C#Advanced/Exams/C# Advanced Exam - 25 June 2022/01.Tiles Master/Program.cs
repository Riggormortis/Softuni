using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTiles = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] greyTiles = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            //from last to first => stack - LIFO
            Stack<int> stackWhiteTiles = new Stack<int>(whiteTiles);

            //from the first to the last => queue - FIFO
            Queue<int> queueGreyTiles = new Queue<int>(greyTiles);

            


            SortedDictionary<string, int> home = new SortedDictionary<string, int> {
                {"Sink", 0 },
                {"Oven", 0 },
                {"Countertop", 0 },
                {"Wall", 0 },
                {"Floor", 0 }

            };

            while (queueGreyTiles.Count > 0 && stackWhiteTiles.Count > 0)
            {
                int currentGrey = queueGreyTiles.Peek();
                int currentWhite = stackWhiteTiles.Peek();

                int sumBoth = currentGrey + currentWhite;

                //Sink    40
                //Oven    50
                //Countertop  60
                //Wall    70

                if (currentGrey == currentWhite)
                {
                    if (sumBoth == 40)
                    {
                        home["Sink"]++;
                        queueGreyTiles.Dequeue();
                        stackWhiteTiles.Pop();
                    }
                    else if (sumBoth == 50)
                    {
                        home["Oven"]++;
                        queueGreyTiles.Dequeue();
                        stackWhiteTiles.Pop();
                    }
                    else if (sumBoth == 60)
                    {
                        home["Countertop"]++;
                        queueGreyTiles.Dequeue();
                        stackWhiteTiles.Pop();
                    }
                    else if (sumBoth == 70)
                    {
                        home["Wall"]++;
                        queueGreyTiles.Dequeue();
                        stackWhiteTiles.Pop();
                    }
                    else
                    {
                        home["Floor"]++;
                        queueGreyTiles.Dequeue();
                        stackWhiteTiles.Pop();
                    }
                }
                else
                {
                    stackWhiteTiles.Pop();
                    currentWhite = currentWhite / 2;
                    stackWhiteTiles.Push(currentWhite);
                    queueGreyTiles.Dequeue();
                    queueGreyTiles.Enqueue(currentGrey);

                }
            }

                if (stackWhiteTiles.Count == 0)
                {
                    Console.WriteLine("White tiles left: none");
                }
                else
                {
                    Console.WriteLine("White tiles left: " + String.Join(", ", stackWhiteTiles));
                }
                if (queueGreyTiles.Count == 0)
                {
                    Console.WriteLine("Grey tiles left: none");
                }
                else
                {
                    Console.WriteLine("Grey tiles left: " + String.Join(", ", queueGreyTiles));
                }

            foreach (var item in home.OrderByDescending(x => x.Value).ThenBy(x => x.Key)) //sort alphabeticaly
            {
                //sword item -> key: swordName, value: swordCount

                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

        }
    }
}
