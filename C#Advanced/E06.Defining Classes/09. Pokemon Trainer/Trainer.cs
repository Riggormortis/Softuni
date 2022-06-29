using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> collectionOfPokemon;

        public string Name { get { return this.name; } set { name = value; } }
        public int NumberOfBadges { get { return numberOfBadges; } set { numberOfBadges = value; } }
        public List<Pokemon> CollectionOfPokemon { get { return collectionOfPokemon; } set { collectionOfPokemon = value; } }

        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            CollectionOfPokemon = new List<Pokemon>();
        }
    }
}
