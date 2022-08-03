using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const string DefaultTrainingHall = "BoxingGym";

        private string trainingHall;


        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, 60)
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
            Stamina += 15;
        }
    }
}
