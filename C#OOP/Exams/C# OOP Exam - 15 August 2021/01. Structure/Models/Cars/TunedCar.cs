﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string vin, int horsePower) : base(make, model, vin, horsePower, 65, 7.5)
        {
        }

            public override void Drive()
            {
            base.Drive();
            var engineWear = HorsePower * 0.03;
            this.HorsePower = (int)(HorsePower - engineWear);
            }
    }
}

