using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;
        private int capacity;
        public Clinic(int capacity)
        {
            this.pets = new List<Pet>();
            this.Capacity = capacity;    
        }

        public int Capacity { get; set; }

        public int Count
            => pets.Count;


        public void Add(Pet pet)
        {
            if (pets.Count < Capacity)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = pets.FirstOrDefault(x => x.Name == name);
            return pets.Remove(pet);
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);

            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet pet = pets.OrderByDescending(x => x.Age)
                .FirstOrDefault();
            return pet;
        }

        public string GetStatistics()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("The clinic has the following patients:");
            foreach (var pet in pets)
            {
                stringBuilder.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return stringBuilder
                .ToString()
                .TrimEnd();
        }
    }
}
