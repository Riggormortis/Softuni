using System;
using System.Linq;
using System.Collections.Generic;
namespace _08.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string cmd = Console.ReadLine();
            int passedcount = 0;
            while (cmd != "end")
            {
                if (cmd == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }

                        var car = cars.Dequeue();
                        Console.WriteLine($"{car} passed!");
                        passedcount++;
                    }
                }
                else
                {
                    cars.Enqueue(cmd);
                }


                cmd = Console.ReadLine();
            }

            Console.WriteLine($"{passedcount} cars passed the crossroads.");
        }
    }
}
