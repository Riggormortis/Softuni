﻿using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => this.models;

        public void Add(ICar model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            models.Add(model);
        }

        public ICar FindBy(string property)
        {
            return models.FirstOrDefault(m => m.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}
