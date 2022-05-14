using System;

namespace _07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            double priceOfTiket = 0;


            if (age >= 0 && age <= 18)
            {
                if (typeOfDay == "Weekday")
                {
                    priceOfTiket = 12;
                }
                else if (typeOfDay == "Weekend")
                {
                    priceOfTiket = 15;
                }
                else if (typeOfDay == "Holiday")
                {
                    priceOfTiket = 5;
                }
                Console.WriteLine($"{priceOfTiket}$");
            }
            else if (age > 18 && age <= 64)
            {
                if (typeOfDay == "Weekday")
                {
                    priceOfTiket = 18;
                }
                else if (typeOfDay == "Weekend")
                {
                    priceOfTiket = 20;
                }
                else if (typeOfDay == "Holiday")
                {
                    priceOfTiket = 12;
                }
                Console.WriteLine($"{priceOfTiket}$");
            }
            else if (age > 64 && age <= 122)
            {
                if (typeOfDay == "Weekday")
                {
                    priceOfTiket = 12;
                }
                else if (typeOfDay == "Weekend")
                {
                    priceOfTiket = 15;
                }
                else if (typeOfDay == "Holiday")
                {
                    priceOfTiket = 10;
                }
                Console.WriteLine($"{priceOfTiket}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }


        }
    }
}
