using System;
using System.Collections.Generic;
using System.Linq;
namespace _07._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            var parking = new HashSet<string>();

            string cmd = Console.ReadLine();
                                

            while (cmd != "END")
            {
                string[] token = cmd.Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

                string direction = token[0];
                string carNumber = token[1];

                if (token[0] == "IN")
                {
                    parking.Add(carNumber);
                }
                else if (token[0] == "OUT")
                {
                    parking.Remove(carNumber);
                }

                cmd = Console.ReadLine();
            }

            if (parking.Any())
            {
                foreach (var carNumber in parking)
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            

        }
    }
}
