using System;

namespace Demos
{
    class Program
    {
        static void Main(string[] args)
        {
                       
            Car bmw = new Car()
            {
                Name = "3",
                Company = "BMW",
                Category = "Cars",
                Price = 3000
            };
            bmw.Drive(10000);
            bmw.Drive(23000);

            Car audi = new Car()
            {
                Name = "A3",
                Company = "Audi",
                Category = "Cars",
                Price = 3500
            };
            audi.Drive(10000);
            audi.Drive(3000);

            Console.WriteLine($"Car: {bmw.Name}, {bmw.Price}, {bmw.Company} - Mileage{bmw.Mileage}");

            Console.WriteLine($"Car: {audi.Name}, {audi.Price}, {audi.Company} - Mileage{audi.Mileage}");

        }
    }
}
