namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private int comfort;


        private Aquarium()
        {
            this.Decorations = new HashSet<IDecoration>();
            this.Fish = new HashSet<IFish>();

        }

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; }

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public int Comfort => this.Decorations.Sum(x => x.Comfort);


        public void AddFish(IFish fish)
        {
            if (this.Fish.Count + 1 > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            else
            {
                this.Fish.Add(fish);
            }
        }
        
        public bool RemoveFish(IFish fish)
        {
            return this.Fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (IFish fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            string fishOutput = this.Fish.Count > 0 ?
                String.Join(", ", this.Fish.Select(f => f.Name)) 
                : "none";

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {fishOutput}");
            sb.AppendLine($"Decorations: {this.Decorations.Count()}");
            sb.Append($"Comfort: {this.Comfort}");

            return sb.ToString().Trim();
        }

        
    }
}
