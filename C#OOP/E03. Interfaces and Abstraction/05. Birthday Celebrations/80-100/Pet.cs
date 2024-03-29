﻿using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IPet, IIdentifiable
    {

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }


        public string Name { get; private set; }

        public string Birthdate { get; private set; }

        public override string ToString()
        {
            return $"{this.Birthdate}";
        }
    }
}
