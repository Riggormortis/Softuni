using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;
        private bool isAvailable = false;

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.username = username;
            this.racingBehavior = racingBehavior;
            this.drivingExperience = drivingExperience;
            this.car = car;
        }

        public string Username
        {
            get => this.username;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }

                this.username = value;
            }
        }

        public string RacingBehavior
        {
            get => this.racingBehavior;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }

                this.racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get => this.drivingExperience;

            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerDrivingExperience, value));
                }

                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => this.car;

            private set
            {
                if (this.car == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }

                this.car = value;
            }
        }

        public virtual void Race()
        {
            car.Drive();
            //TODO Driver Experience
        }

        public bool IsAvailable()
        {
           if (car.FuelAvailable >= car.FuelConsumptionPerRace)
            {
                isAvailable = true;
            }

            return isAvailable;
        }

        
    }
}
