using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private int numberOfWins;
        private double oxygen;
        private ICar car;
        private bool canParticipate;


        public Driver(string name)
        {
            Name = name;
        }


        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName));
                }
                this.name = value;
            }
        }

        public ICar Car
        {
            get => car;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.CarInvalid);
                }

                car = value;
            }
        }

        public int NumberOfWins
        {
            get => this.numberOfWins;
            private set
            {
                this.numberOfWins = value;
            }
        }

        public bool CanParticipate
        {
            get => canParticipate;
            private set => canParticipate = value;
        }

        public void AddCar(ICar car)
        {
            Car = car;
            CanParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
