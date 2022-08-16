using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel = 1;

        

        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            
        }

        public double Cost
        {
            get => cost;
            private set
            {
                //if (value < 0)
                //{
                //    throw new ArgumentException("Price cannot be negative.");
                //}
                this.cost = value;
            }
        }

        public int EnduranceLevel => enduranceLevel;
        

        public void IncreaseEndurance()
        {
            this.enduranceLevel++;
            if (enduranceLevel > 20)
            {
                enduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
