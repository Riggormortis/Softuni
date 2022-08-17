using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            
            List<string> itemsOnPlanet = planet.Items.ToList();

            foreach (var astronaut in astronauts.Where(a => a.CanBreath == true))
            {
                for (int i = 0; i < itemsOnPlanet.Count; i++)
                {
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(itemsOnPlanet[i]);
                    itemsOnPlanet.RemoveAt(i);
                    i--;

                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                }
            }
        }
    }
}
