using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IDriver> drivers;


        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;

            drivers = new List<IDriver>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get => laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfLaps);
                }

                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);
            }
            if (driver.Car == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (drivers.FirstOrDefault(d => d.Name == driver.Name) != null)
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, Name));
            }
            drivers.Add(driver);
        }
    }
}
