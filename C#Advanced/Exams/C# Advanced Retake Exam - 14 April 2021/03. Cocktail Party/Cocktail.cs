using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;
        private string name;
        private int capacity;
        private int maxAlcoholLevel;

        public string Name { get => name; set => name = value; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public List<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }
        public int CurrentAlcoholLevel => this.Ingredients.Sum(x => x.Alcohol);

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Any(x => x.Name == ingredient.Name) && Ingredients.Count < Capacity)
            {
                Ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(x => x.Name == name);
            if (ingredient == null)
            {
                return false;
            }
            Ingredients.Remove(ingredient);
            return true;
        }

        public Ingredient FindIngredient(string name)

        {
            Ingredient ingredient = ingredients.FirstOrDefault(x => x.Name == name);
            if (ingredient == null)
            {
                return null;
            }
            else
            {
                return ingredient;
            }
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient mostAlcoholicIngridient = Ingredients.OrderBy(x => x.Alcohol).Last();
            return mostAlcoholicIngridient;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}").AppendLine(string.Join(Environment.NewLine, ingredients));
            return sb.ToString().TrimEnd();
        }

    }
}
