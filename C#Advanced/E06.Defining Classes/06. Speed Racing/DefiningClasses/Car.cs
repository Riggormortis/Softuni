using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        //fields - harakteritiki na kolite
        private string model;
        private double fuelAmount;
        private double fuelConsumptionperKm;
        private double distance;

        //constructor - creating object of the class
        public Car(string model, double fuelAmount, double fuelConsumptionperKm)
        {
            //new object
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumptionperKm;
            Distance = 0;

        }
        //methods - functionalities of the cars
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double Distance { get; set; }

        public void Drive(double amountOfKm)
        {
            //to be able to cross the distance
            double neededLiters = amountOfKm * FuelConsumptionPerKm;

            if (FuelAmount >= neededLiters)
            {
                FuelAmount -= neededLiters;
                Distance += amountOfKm;
            }
            //to not be abel to cross the distance
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
