using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository formulaOneCarRepository;
        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            formulaOneCarRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            if (this.pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            Pilot pilot = new Pilot(fullName);

            this.pilotRepository.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

      
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car;

            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            if (formulaOneCarRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            formulaOneCarRepository.Add(car);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = new Race(raceName, numberOfLaps);

            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            raceRepository.Add(race);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = formulaOneCarRepository.FindByName(carModel);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (car == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            formulaOneCarRepository.Remove(car);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);

        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.Pilots.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }
        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            race.TookPlace = true;

            List<IPilot> orderedPilots = race.Pilots.OrderByDescending(r => r.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToList();

            IPilot winner = orderedPilots[0];
            winner.WinRace();

            IPilot secondPlace = orderedPilots[1];
            IPilot thirdPlace = orderedPilots[2];

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Pilot {winner.FullName} wins the {race.RaceName} race.");
            sb.AppendLine($"Pilot {secondPlace.FullName} is second in the {race.RaceName} race.");
            sb.AppendLine($"Pilot {thirdPlace.FullName} is third in the {race.RaceName} race.");

            return sb.ToString().TrimEnd();
        }
        public string RaceReport()
        {
            List<IRace> executedRaces = raceRepository.Models.Where(r => r.TookPlace == true).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var race in executedRaces)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            List<IPilot> orderedPilots = pilotRepository.Models.OrderByDescending(p => p.NumberOfWins).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var pilot in orderedPilots)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
   
    }
}
