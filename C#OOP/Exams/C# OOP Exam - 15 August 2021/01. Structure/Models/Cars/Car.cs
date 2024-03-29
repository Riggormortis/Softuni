﻿using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        protected Car(string make, string model, string vin, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.make = make;
            this.model = model;
            this.vin = vin;
            this.horsePower = horsePower;
            this.fuelAvailable = fuelAvailable;
            this.fuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get => this.make;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }

                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }

                this.model = value;
            }
        }

        public string VIN
        {
            get => this.vin;

            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }

                this.vin = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }

                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => this.fuelAvailable;

            private set
            {
                this.fuelAvailable = value;
                if (value < 0)
                {
                    fuelAvailable = 0;
                }               
            }
        }

        public double FuelConsumptionPerRace
        {
            get => this.fuelConsumptionPerRace;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }

                this.fuelConsumptionPerRace = value;
            }
        }

        public virtual void Drive()
        {
            this.fuelAvailable -= fuelConsumptionPerRace;
        }
    }
}
