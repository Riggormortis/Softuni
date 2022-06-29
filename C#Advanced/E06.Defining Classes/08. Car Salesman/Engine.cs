using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public string Model { get { return model; } set { model = value; } }
        public int Power { get { return power; } set { power = value; } }
        public int Displacement { get { return displacement; } set { displacement = value; } }
        public string Efficiency { get { return efficiency; } set { efficiency = value; } }
        public Engine()
        {
            Displacement = 0;
            Efficiency = string.Empty;
        }
        public Engine(string model, int power, int displavement, string efficiency)
        : this()
        {
            Model = model;
            Power = power;
            Displacement = displavement;
            Efficiency = efficiency;
        }
    }
}