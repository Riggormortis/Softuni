﻿using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {

        private readonly DecorationRepository decorations;
        private readonly ICollection<IAquarium> aquariums;


        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new HashSet<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            this.aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            this.decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }
        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IDecoration decoration = this.decorations.FindByType(decorationType);

            if (decoration == null) //decorations?
            {
                throw new InvalidOperationException(string
                    .Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            aquarium?.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);

        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IFish fish;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            string aquariumType = aquarium?.GetType().Name.Replace("Aquarium", string.Empty);
            string fishTypeStr = fishType?.Replace("Fish", string.Empty);

            if (aquariumType == fishTypeStr)
            {
                aquarium.AddFish(fish);
            }

            string output = aquariumType != fishTypeStr ? OutputMessages.UnsuitableWater
                : string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);

            //if (aquariumType == fishTypeStr)
            //{
            //    aquarium.AddFish(fish);
            //    return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            //}
            //else
            //{
            //    return String.Format(OutputMessages.UnsuitableWater); //razliki i tuka
            //}

            return output;

        }
        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium?.Feed();
            return String.Format(OutputMessages.FishFed, aquarium?.Fish.Count());
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            decimal valueFish = aquarium.Fish.Sum(f => f.Price);
            decimal valueDecoration = aquarium.Decorations.Sum(d => d.Price);
            decimal totalValue = valueFish + valueDecoration;

            return string.Format(OutputMessages.AquariumValue, aquariumName, totalValue);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (IAquarium aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }


        private IAquarium CreateAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new SaltwaterAquarium(aquariumName);

            }
            return aquarium;
        }
    }
}

