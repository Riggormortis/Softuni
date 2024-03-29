﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        string make;
        string model;
        int year;
        double fuelQuantity;
        double fuelConsumption;

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
             
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {

            Engine = engine;
            Tires = tires;
        }


        public string Make { get { return this.make; } set { this.make = value; } }

        public string Model { get { return this.model; } set { this.model = value; } }

        public int Year { get { return this.year; } set { this.year = value;}}
        public double FuelQuantity { get { return this.fuelQuantity; } set { this.fuelQuantity = value; } }

        public double FuelConsumption { get { return this.fuelConsumption; } set { this.fuelConsumption = value; } }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            if (fuelQuantity - distance * fuelConsumption > 0)
            {
                fuelQuantity -= distance * fuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: { this.Year}");
            sb.AppendLine($"Fuel: { this.FuelQuantity:F2}L");

            return sb.ToString();
        }
    }
}
