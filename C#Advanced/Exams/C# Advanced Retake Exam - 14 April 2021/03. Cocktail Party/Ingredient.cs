using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        private string name;
        private int alcohol;
        private int quantity;

        public string Name { get => name; set => name = value; }
        public int Alcohol { get => alcohol; set => alcohol = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Ingredient: {Name}")
                .AppendLine($"Quantity: {Quantity}")
                .AppendLine($"Alcohol: {Alcohol}");
            return sb.ToString().TrimEnd();
        }
    }
}
