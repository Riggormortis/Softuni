﻿namespace Heroes.Repositories
{
    using Contracts;
    using Models.Contracts;
    using System.Collections.Generic;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly Dictionary<string, IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new Dictionary<string, IWeapon>();
        }


        public IReadOnlyCollection<IWeapon> Models => this.weapons.Values;

        public void Add(IWeapon model)
        {
            this.weapons.Add(model.Name, model);
        }

        public IWeapon FindByName(string name)
        {
            if (this.weapons.ContainsKey(name))
            {
                return this.weapons[name];
            }

            return null;
        }

        public bool Remove(IWeapon model)
        {
            if (this.weapons.ContainsKey(model.Name))
            {
                this.weapons.Remove(model.Name);

                return true;
            }

            return false;
        }
    }
}
