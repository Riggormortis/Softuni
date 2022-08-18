using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Cars
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsePower;
        private double engineDisplacement;

        protected FormulaOneCar(string model, int horsePower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsePower;
            EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get => this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }

                this.model = value;
            }
        }

        public int Horsepower
        {
            get => this.horsePower;

            private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public double EngineDisplacement
        {
            get => this.engineDisplacement;

            private set
            {
                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }

                this.engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            var raceScore = EngineDisplacement / Horsepower * laps;
            return raceScore;
        }
    }
}
