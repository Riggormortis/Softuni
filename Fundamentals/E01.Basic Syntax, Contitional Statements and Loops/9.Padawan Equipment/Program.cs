using System;

namespace _9.Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            //The amount of money John has – the floating-point number in the range[0.00…1, 000.00]
            // The count of students – integer in the range[0…100]
            // The price of lightsabers for a single saber – the floating - point number in the range[0.00…100.00]
            // The price of robes for a single robe – the floating - point number in the range[0.00…100.00]
            // The price of belts for a single belt – the floating - point number in the range[0.00…100.00]

            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            double totalLightSabersPrice = Math.Ceiling(students + 0.1 * students) * lightsaberPrice;
            double totalRobesPrice = students * robesPrice;
            double totalBeltPrice = students * beltsPrice;

            int freeBelt = (students / 6);


            // The output should be printed on the console.
            //  If the calculated price of the equipment is less or equal to the money John has:
            // "The money is enough - it would cost {the cost of the equipment}lv."
            // If the calculated price of the equipment is more than the money John has:
            // " John will need {neededMoney}lv more."
            // All prices must be rounded to two digits after the decimal point.

            double totalPriceOfAll = totalLightSabersPrice + totalRobesPrice + (totalBeltPrice - (freeBelt * beltsPrice));

            if (money >= totalPriceOfAll)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPriceOfAll:f2}lv.");
            }
            else if (money < totalPriceOfAll)
            {
                Console.WriteLine($" John will need {totalPriceOfAll - money:f2}lv more.");
            }

        }
    }
}
