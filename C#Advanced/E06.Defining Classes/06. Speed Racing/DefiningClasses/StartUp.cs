using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // number of cars

            List<Car> cars = new List<Car>();

            for (int i = 1; i <= n; i++)
            {
                string data = Console.ReadLine(); //"{model} {fuelAmount} {fuelConsumptionFor1km}"
                string model = data.Split()[0];
                double fuelAmount = double.Parse(data.Split()[1]);
                double fuelConsumptionperKm = double.Parse(data.Split()[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionperKm);

                cars.Add(car);
            }


            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                
                    string carModel = cmd.Split()[1];
                    double amountOfKm = int.Parse(cmd.Split()[2]);

                    Car carToDrive = cars.First(car => car.Model == carModel);
                    carToDrive.Drive(amountOfKm);
                

                cmd = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                //"{model} {fuelAmount} {distanceTraveled}"
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Distance}");
            }
        }
    }
}
