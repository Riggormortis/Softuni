using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private const int startingCombatExpirience = 0;
        private const int aditionalCombatExpirience = 10;

        private string fullName;
        private int combatExperience;
        private List<IVessel> vessels;


        public Captain(string fullName)
        {
            this.FullName = fullName;

            this.CombatExperience = startingCombatExpirience;

            this.vessels = new List<IVessel>();
        }



        public string FullName
        {
            get
            {
                return fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);

                }
                fullName = value;
            }
        }

        public int CombatExperience
        {
            get => this.combatExperience;
            private set
            {
                this.combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels => this.vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.combatExperience += aditionalCombatExpirience;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            if (this.Vessels.Any())
            {
                foreach (IVessel vessel in this.Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
