using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;
        public string Model { get { return model; } set { model = value; } }
        public Engine Engine { get { return engine; } set { engine = value; } }
        public int Weght { get { return weight; } set { weight = value; } }
        public string Color { get { return color; } set { color = value; } }

        public Car()
        {
            weight = 0;
            color = string.Empty;
        }
        public Car(string model, Engine engine, int weight, string color)
            : this()
        {
            Model = model;
            Engine = engine;
            Weght = weight;
            Color = color;
        }

    }
}
