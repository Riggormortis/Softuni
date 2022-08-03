﻿using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;

        private string motivation;

        private int stamina;

        private int numberOfMedals;

        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }

        
        public string FullName
        {
            get 
            {
                return this.fullName; 
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName); //we took it from ExeptionMessages class
                }
                this.fullName = value; 
            }
        }

        public string Motivation
        {
            get
            {
                return this.motivation;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation); //we took it from ExeptionMessages class
                }
                this.motivation = value;
            }
        }

        public int Stamina
        {
            get { return this.stamina;}
            protected set
            {
                if (value > 100)
                {
                    Stamina = 100;
                    throw new ArgumentException(ExceptionMessages.InvalidStamina);
                }
                this.stamina = value;
            }
        }

        public int NumberOfMedals
        {
            get
            {
                return this.numberOfMedals;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals); //we took it from ExeptionMessages class
                }
                this.numberOfMedals = value;
            }
        }

        public abstract void Exercise();
       
    }
}
