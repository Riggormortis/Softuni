using System.Text;

namespace Zoo
{
    public class Animal
    {
        private string species;
        private string diet;
        private double weight;
        private double length;

        public string Species { get => species; private set { species = value; } }
        public string Diet { get => diet; private set { diet = value; } }
        public double Weight { get => weight; private set { weight = value; } }
        public double Length { get => length; private set { length = value; } }

        public Animal(string species, string diet, double weight, double length)
        {
            this.Species = species;
            this.Diet = diet;
            this.Weight = weight;
            this.Length = length;
        }

        public override string ToString()
        {
            return $"The {this.Species} is a {this.Diet} and weighs {this.Weight} kg.";
        }


    }
}
