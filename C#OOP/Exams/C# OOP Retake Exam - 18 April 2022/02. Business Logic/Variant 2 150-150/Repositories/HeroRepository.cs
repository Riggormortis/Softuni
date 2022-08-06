using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.heroes.AsReadOnly();

        public void Add(IHero model)
        {
            this.heroes.Add(model);
        }

        public bool Remove(IHero model)
        {
            if (this.heroes.Any(m => m.Name == model.Name))
            {
                this.heroes.Remove(model);

                return true;
            }

            return false;
        }

        public IHero FindByName(string name)
        {
            return this.heroes.FirstOrDefault(h => h.Name == name);
        }

        
    }
}
