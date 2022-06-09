using System;
using System.Collections.Generic;
using System.Text;

namespace DemoConstructor
{
    public class Animal
    {
        public Animal(string name, string species, string gender, bool isHungry)
        {
            Name = name;
            Species = species;
            Gender = gender;
            IsHungry = isHungry;

        }

        public Animal(string name)
        {
            Name = name;
        }

        public string Species { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public bool IsHungry { get; set; }


    }
}
