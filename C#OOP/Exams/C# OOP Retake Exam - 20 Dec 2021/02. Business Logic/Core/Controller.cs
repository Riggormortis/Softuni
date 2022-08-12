using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private IDictionary<string, ICaptain> captainsByName;


        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captainsByName = new Dictionary<string, ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            if (this.captainsByName.ContainsKey(fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            ICaptain captain = new Captain(fullName);

            this.captainsByName.Add(fullName, captain);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }


        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (this.vessels.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            IVessel vessel = null;


            if (vesselType == nameof(Submarine)) //or nameof
            {
                 vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == nameof(Battleship))
            {
                 vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return String.Format(OutputMessages.InvalidVesselType);
            }

            this.vessels.Add(vessel);

            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }


        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            
            if (!this.captainsByName.ContainsKey(selectedCaptainName))
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            ICaptain captain = this.captainsByName[selectedCaptainName];

            if (this.vessels.FindByName(selectedVesselName) == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            IVessel vessel = this.vessels.FindByName(selectedVesselName);

            if (vessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);

        }

        public string CaptainReport(string captainFullName) => this.captainsByName[captainFullName].Report();
        

        public string VesselReport(string vesselName)
        {
            return this.vessels.FindByName(vesselName).ToString();
        }


        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType().Name == nameof(Battleship))
            {
                IBattleship battleship = this.vessels.FindByName(vesselName) as IBattleship;

                battleship.ToggleSonarMode();

                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            
                ISubmarine submarine = this.vessels.FindByName(vesselName) as ISubmarine;

                submarine.ToggleSubmergeMode();

                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();

            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel atackVessel = this.vessels.FindByName(attackingVesselName);
            
            if (atackVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            IVessel deffenderVessel = this.vessels.FindByName(defendingVesselName);

            if (deffenderVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (atackVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (deffenderVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            atackVessel.Attack(deffenderVessel);
            atackVessel.Captain.IncreaseCombatExperience();
            deffenderVessel.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, deffenderVessel.ArmorThickness);


        }



    }
}
