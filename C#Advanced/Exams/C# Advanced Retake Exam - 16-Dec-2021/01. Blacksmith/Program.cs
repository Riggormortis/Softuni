using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] steel = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            int[] carbon = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            //steel - from the first to the last => queue - FIFO
            Queue<int> queueSteel = new Queue<int>(steel);

            //carbon - from last to first => stack - LIFO
            Stack<int> stackCarbon = new Stack<int>(carbon);

            


            // sword name => count swords

            //Sort alphabetically - SortedDictionary
            SortedDictionary<string, int> swords = new SortedDictionary<string, int> {
                {"Broadsword", 0 },
                {"Sabre", 0 },
                {"Katana", 0 },
                {"Shamshir", 0 },
                {"Gladius", 0 }
            };

            // STOP forging when we have no more steel OR carbon left
            //Continue if we have steel and carbon
            //1. taking first steel(peek) = last carbon (peek)
            //2. steel + carbon = sum
            //Sword Resources needed
            //Gladius - 70
            //Shamshir  -  80
            //Katana - 90
            //Sabre -  110
            //Broadsword - 150
            //3. check is the sum is enough for a sword
            //3.1. if enough => dequeue steel; pop carbon
            //3.2 if not enough => dequeue steel and add +5 to carbon

            int totalswords = 0; //sum of all crafted swords
            while (queueSteel.Count >0 && stackCarbon.Count > 0)
            {
                int currentSteel = queueSteel.Peek();
                int currentCarbon = stackCarbon.Peek();
                int sum = currentSteel + currentCarbon;
                if (sum == 70)
                {
                    swords["Gladius"]++;
                    totalswords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 80)
                {
                    swords["Shamshir"]++;
                    totalswords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 90)
                {
                    swords["Katana"]++;
                    totalswords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 110)
                {
                    swords["Sabre"]++;
                    totalswords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 150)
                {
                    swords["Broadsword"]++;
                    totalswords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else
                {
                    queueSteel.Dequeue();
                    currentCarbon += 5;
                    stackCarbon.Pop();
                    stackCarbon.Push(currentCarbon);
                }
            }
            //if one of the resources ends

            if (totalswords >= 1)
            {
                Console.WriteLine($"You have forged {totalswords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (queueSteel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine("Steel left: " + String.Join(", ", queueSteel));
            }
            if (stackCarbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine("Carbon left: " + String.Join(", ", stackCarbon));
            }

            //printing swords
            foreach (var swordItem in swords.OrderBy(pair => pair.Key)) //sort alphabeticaly
            {
                //sword item -> key: swordName, value: swordCount

                if (swordItem.Value > 0)
                {
                    Console.WriteLine($"{swordItem.Key}: {swordItem.Value}");
                }
            }
        }
    }
}
