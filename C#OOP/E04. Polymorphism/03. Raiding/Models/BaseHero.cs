using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero: IBaseHero

    {
        protected BaseHero(string name)
        {
            this.Name = name;
           
        }


        public string Name { get; private set; }

        public virtual int Power { get; private set; }


        public virtual string CastAbility()
        {
            return null;
        }
    }
}
