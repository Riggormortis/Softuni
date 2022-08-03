using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const string DefaultTrainingHall = "WeightliftingGym";

        private string trainingHall;

        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, 50)
        {
            this.TrainingHall = DefaultTrainingHall;
        }

        public string TrainingHall
        {
            get => this.trainingHall;
            private set
            {
                this.trainingHall = value;
            }
        }


        public override void Exercise()
        {
            Stamina += 10;
        }
    }
}
