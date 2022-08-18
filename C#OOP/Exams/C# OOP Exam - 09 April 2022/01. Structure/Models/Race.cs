﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace = false;
        private ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
 
            this.pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => this.raceName;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }

                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => this.numberOfLaps;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                this.numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get => tookPlace;
            set => tookPlace = value;
        }

        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The {this.RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            if (TookPlace == true)
            {
                sb.AppendLine($"Took place: Yes");
            }
            else
            {
                sb.AppendLine($"Took place: No");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
