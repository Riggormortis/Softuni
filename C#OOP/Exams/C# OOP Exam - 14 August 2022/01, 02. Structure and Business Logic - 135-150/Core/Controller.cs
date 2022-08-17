using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        

        public Controller()
        {
            this.planets = new PlanetRepository();
            
        }


        public string CreatePlanet(string name, double budget)
        {
            if (this.planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            Planet planet = new Planet(name, budget);

            this.planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }


        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = this.planets.FindByName(planetName);

            if (this.planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            
            foreach (IMilitaryUnit addedUnit in planet.Army)
            {
                if (addedUnit.GetType().Name == unitTypeName)
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                }
            }



            IMilitaryUnit unit = unitTypeName switch
            {
                nameof(AnonymousImpactUnit) => new AnonymousImpactUnit(),
                nameof(SpaceForces) => new SpaceForces(),
                nameof(StormTroopers) => new StormTroopers(),
                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName))
            };

            


            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }


        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (this.planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            foreach (IWeapon addedWeapon in planet.Army)
            {
                if (addedWeapon.GetType().Name == weaponTypeName)
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                }
            }

            IWeapon weapon = weaponTypeName switch
            {
                nameof(BioChemicalWeapon) => new BioChemicalWeapon(destructionLevel),
                nameof(NuclearWeapon) => new NuclearWeapon(destructionLevel),
                nameof(SpaceMissiles) => new SpaceMissiles(destructionLevel),
                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName))
            };
                             
            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            if (this.planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = this.planets.FindByName(planetName);
            if (planet.Army is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound, planetName));
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet atackerPLanet = this.planets.FindByName(planetOne);

            IPlanet defenderPlanet = this.planets.FindByName(planetTwo);

            bool AtackerHasNuclear = atackerPLanet.Weapons.Any(w => w is NuclearWeapon);
            bool DefenderHasNuclear = defenderPlanet.Weapons.Any(w => w is NuclearWeapon);

            IPlanet winner = null;
            IPlanet loser = null;

            if (atackerPLanet.MilitaryPower == defenderPlanet.MilitaryPower)
            {
                 
                if (AtackerHasNuclear && !DefenderHasNuclear)
                {
                    winner = atackerPLanet;
                    loser = defenderPlanet;
                    
                }
                else if (!AtackerHasNuclear && DefenderHasNuclear)
                {
                    winner = defenderPlanet;
                    loser = atackerPLanet;
                }
                else
                {
                    atackerPLanet.Spend(atackerPLanet.Budget / 2);
                    defenderPlanet.Spend(defenderPlanet.Budget / 2);
                    return OutputMessages.NoWinner;
                }
            }
            else if (atackerPLanet.MilitaryPower > defenderPlanet.MilitaryPower)
            {
                winner = atackerPLanet;
                loser = defenderPlanet;
            }
            else if (atackerPLanet.MilitaryPower < defenderPlanet.MilitaryPower)
            {
                winner = defenderPlanet;
                loser = atackerPLanet;
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);
            winner.Profit(loser.Army.Sum(u => u.Cost) + loser.Weapons.Sum(w => w.Price));

            planets.RemoveItem(loser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);

        }

        public string ForcesReport()
        {
            var ordered = planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in ordered)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
