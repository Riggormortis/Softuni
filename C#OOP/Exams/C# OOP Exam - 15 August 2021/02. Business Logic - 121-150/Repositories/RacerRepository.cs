﻿using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly List<IRacer> models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }


        public IReadOnlyCollection<IRacer> Models => this.models;

        public void Add(IRacer model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return models.FirstOrDefault(m => m.Username == property);
        }

        public bool Remove(IRacer model)
        {
            return this.models.Remove(model);
        }
    }
}
