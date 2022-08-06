namespace Heroes.Repositories
{
    using Contracts;
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }


        public IReadOnlyCollection<IWeapon> Models => this.weapons.AsReadOnly();

        public void Add(IWeapon model)
        {
            this.weapons.Add(model);
        }

        public bool Remove(IWeapon model)
        {
            if (this.weapons.Any(m => m.Name == model.Name))
            {
                this.weapons.Remove(model);

                return true;
            }

            return false;
        }

        public IWeapon FindByName(string name)
        {
            return this.weapons.FirstOrDefault(m => m.Name == name);
        }

        
    }
}
