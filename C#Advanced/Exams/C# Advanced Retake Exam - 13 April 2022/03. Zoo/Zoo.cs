using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;
        private string name;
        private int capacity;


        public Zoo()
        {
            this.animals = new List<Animal>();
        }
        public Zoo(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }


        public string Name { get => this.name; private set { this.name = value; } }
        public int Capacity { get => this.capacity; private set { capacity = value; } }
        public List<Animal> Animals
        {
            get => this.animals; private set { }
        }



        public string AddAnimal(Animal animal)
        {
            
                if (string.IsNullOrWhiteSpace(animal.Species))
                {
                    return "Invalid animal species.";
                }
                else if (!((animal.Diet.ToLower().Equals("herbivore")) || (animal.Diet.ToLower().Equals("carnivore"))))
                {
                return "Invalid animal diet.";
                }
                else if (this.Capacity.Equals(this.animals.Count))
                {
                    return "The zoo is full.";
                }
                else
                {
                    this.animals.Add(animal);
                    return $"Successfully added {animal.Species} to the zoo.";
                }

            return "";
            
        }

        public int RemoveAnimals(string species)
        {
            List<Animal> residentAnimals = this.animals.Where(animal => !animal.Species.Equals(species)).ToList();
            int removedAnimals = this.animals.Count - residentAnimals.Count;
            this.animals = residentAnimals;
            return removedAnimals;

        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return this.animals.Where(a => a.Diet == diet).ToList();
            
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return this.animals.FirstOrDefault(x => x.Weight == weight);
           
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            List<Animal> counter = this.animals.Where(x => (x.Length >= minimumLength) && (x.Length <= maximumLength)).ToList();

            return $"There are {counter.Count} animals with a length between {minimumLength} and {maximumLength} meters.";

        }


    }
}
