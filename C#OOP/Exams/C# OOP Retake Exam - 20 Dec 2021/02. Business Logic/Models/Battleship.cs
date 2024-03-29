﻿using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double initialArmourTickness = 300;
        private const bool DefaultSonarMode = false;
        private const double AdditionToMainWeaponCaliber = 40;
        private const double AdditionToSpeed = 5;

        private bool sonarMode;


        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, initialArmourTickness, mainWeaponCaliber, speed)
        {
            this.SonarMode = DefaultSonarMode;
        }


        public bool SonarMode
        {
            get => this.sonarMode;
            private set
            {
                this.sonarMode = value;
            }
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode)
            {
                this.SonarMode = false;
            }
            else
            {
                this.SonarMode = true;
            }

            if (this.SonarMode)
            {
                this.MainWeaponCaliber += AdditionToMainWeaponCaliber;
                this.Speed -= AdditionToSpeed;
            }
            else
            {
                this.MainWeaponCaliber -= AdditionToMainWeaponCaliber;
                this.Speed += AdditionToSpeed;
            }
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = initialArmourTickness;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (this.SonarMode)
            {
                sb.AppendLine(" *Sonar mode: ON");
            }
            else
            {
                sb.AppendLine(" *Sonar mode: OFF");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
