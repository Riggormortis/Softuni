using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {


        private string name;
        private double budget;
        private double militaryPower;
        private UnitRepository units;
        private WeaponRepository weapons;


        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }


        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                this.budget = value;
            }
        }

        public double MilitaryPower => GetMilitaryPower();
        //{
        //    get => Math.Round(this.militaryPower, 3);
        //    private set
        //    {
        //        double totalAmountSum = 0;
        //        bool hasAnonymous = false;
        //        bool hasNuclear = false;

        //        foreach (var unit in Army)
        //        {
        //            totalAmountSum += unit.EnduranceLevel;

        //            if (unit is AnonymousImpactUnit)
        //            {
        //                hasAnonymous = true;
        //            }

        //        }
        //        foreach (var weapon in Weapons)
        //        {
        //            totalAmountSum += weapon.DestructionLevel;
        //            if (weapon is NuclearWeapon)
        //            {
        //                hasNuclear = true;
        //            }
        //        }

        //        if (hasAnonymous)
        //        {
        //            totalAmountSum *= 1.3;
        //        }
        //        if (hasNuclear)
        //        {
        //            totalAmountSum *= 1.45;
        //        }
        //        militaryPower = totalAmountSum;
        //    }


        //}

        public IReadOnlyCollection<IMilitaryUnit> Army =>  units.Models;

        public IReadOnlyCollection<IWeapon> Weapons =>  weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {   
            if (Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            this.Budget -= amount;
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public string PlanetInfo()
        {
            string forcesAsString = Army.Any() ? string.Join(", ", Army.Select(u => u.GetType().Name)) : "No units";
            string weaponsAsString =
                Weapons.Any() ? string.Join(", ", Weapons.Select(w => w.GetType().Name)) : "No weapons";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine($"--Forces: {forcesAsString}");
            sb.AppendLine($"--Combat equipment: {weaponsAsString}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }


        private double GetMilitaryPower()
        {
            double total = this.Weapons.Sum(w => w.DestructionLevel) + this.Army.Sum(u => u.EnduranceLevel);

            if (Army.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
            {
                total *= 1.3;
            }

            if (Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                total *= 1.45;
            }

            return Math.Round(total, 3);
        }

    }
}
