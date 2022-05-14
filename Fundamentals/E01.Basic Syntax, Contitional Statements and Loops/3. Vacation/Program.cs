using System;

namespace _3._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            //A count of people, which are going on vacation.
            //Type of the group(Students, Business, or Regular).
            // The day of the week which the group will stay(Friday, Saturday, or Sunday).

            int people = int.Parse(Console.ReadLine());
            string typePeople = Console.ReadLine();
            string day = Console.ReadLine();

            double pricePerPerson = 0;


            if (typePeople == "Students")
            {
                if (day == "Friday")
                {
                    pricePerPerson = 8.45;
                }
                else if (day == "Saturday")
                {
                    pricePerPerson = 9.8;
                }
                else if (day == "Sunday")
                {
                    pricePerPerson = 10.46;
                }
                double total = people * pricePerPerson;
                if (people >= 30)
                {
                    total = total * 0.85;
                }

                Console.WriteLine($"Total price: {total:f2}");

            }
            else if (typePeople == "Business")
            {
                if (day == "Friday")
                {
                    pricePerPerson = 10.9;
                }
                else if (day == "Saturday")
                {
                    pricePerPerson = 15.6;
                }
                else if (day == "Sunday")
                {
                    pricePerPerson = 16;
                }

                if (people >= 100)
                {
                    people = people - 10;
                }
                double total = people * pricePerPerson;
                Console.WriteLine($"Total price: {total:f2}");


            }
            else if (typePeople == "Regular")
            {
                if (day == "Friday")
                {
                    pricePerPerson = 15;
                }
                else if (day == "Saturday")
                {
                    pricePerPerson = 20;
                }
                else if (day == "Sunday")
                {
                    pricePerPerson = 22.5;
                }
                double total = people * pricePerPerson;

                if (people >= 10 & people <= 20)
                {
                    total = total * 0.95;
                }

                Console.WriteLine($"Total price: {total:f2}");
            }

            //There are also discounts based on some conditions:
            //For Students, if the group is 30 or more people, you should reduce the total price by 15 %
            //For Business, if the group is 100 or more people, 10 of the people stay for free.
            //For Regular, if the group is between 10 and 20  people(both inclusively), reduce the total price by 5 %
            //Note: You should reduce the prices in that EXACT order!
            //As an output print the final price which the group is going to pay in the format: "Total price: {price}"
            //The price should be formatted to the second decimal point.
        }
    }
}
