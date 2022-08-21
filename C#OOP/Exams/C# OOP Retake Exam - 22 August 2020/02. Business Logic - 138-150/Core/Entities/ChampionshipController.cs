using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository drivers;
        private RaceRepository races;
        private CarRepository cars;

        public ChampionshipController()
        {
            drivers = new DriverRepository();
            cars = new CarRepository();
            races = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            
            this.drivers.Add(new Driver(driverName));
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            
            if (cars.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            cars.Add(car);
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = drivers.GetByName(driverName);
            ICar car = cars.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IDriver driver = drivers.GetByName(driverName);
            IRace race = races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }
               
        public string CreateRace(string name, int laps)
        {           
            if (races.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var currRace = races.GetByName(raceName);

            if (currRace == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (currRace.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            races.Remove(currRace);

            List<IDriver> orderedPilots = currRace.Drivers.OrderByDescending(r => r.Car.CalculateRacePoints(currRace.Laps)).Take(3).ToList();

            IDriver winner = orderedPilots[0];
            winner.WinRace();

            IDriver secondPlace = orderedPilots[1];
            IDriver thirdPlace = orderedPilots[2];

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {winner.Name} wins {raceName} race.");
            sb.AppendLine($"Driver {secondPlace.Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {thirdPlace.Name} is third in {raceName} race.");

            return sb.ToString().TrimEnd();

        }
    }
}
