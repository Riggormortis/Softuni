using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine()); //food we have
            List<int> ordersList = Console.ReadLine()
                                    .Split(' ')
                                    .Select(int.Parse).ToList();
            Queue<int> ordersQueue = new Queue<int>(ordersList); //54 30 16 7 9
            Console.WriteLine(ordersQueue.Max()); //biggest order in the queue

            //making orders
            int countOrders = ordersQueue.Count; //<- number of orders

            for (int order = 1; order <= countOrders; order++)
            {
                if (quantityFood >= ordersQueue.Peek())
                {
                    quantityFood -= ordersQueue.Peek();
                    ordersQueue.Dequeue();
                }
                else
                {
                    //not enough food
                    break;
                }
            }

            //if we completed all the orders
            if (ordersQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                //if we didnt complete all the orders
                Console.WriteLine("Orders left: " + string.Join(" ", ordersQueue));
            }
        }
    }
}
