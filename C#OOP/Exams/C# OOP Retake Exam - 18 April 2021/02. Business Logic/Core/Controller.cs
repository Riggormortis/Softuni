using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBunny> bunnies;
        private readonly IRepository<IEgg> eggs;
        private readonly IWorkshop workshop;
        private int countOfColoredEggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
            this.workshop = new Workshop();
            this.countOfColoredEggs = 0;
        }


        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;


           if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            this.bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);

            bunny.Dyes.Add(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this.eggs.Add(egg); 

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = this.eggs.FindByName(eggName);

            List<IBunny> bunnies = this.bunnies.Models
                .Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy)
                .ToList();

            if (!bunnies.Any())
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.BunniesNotReady));
            }
            
            foreach (var bunny in bunnies)
            {
                this.workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    this.bunnies.Remove(bunny);
                }

                if (egg.IsDone())
                {
                    countOfColoredEggs++;

                    return String.Format(OutputMessages.EggIsDone, eggName);
                }            
            }

            return String.Format(OutputMessages.EggIsNotDone, eggName);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine($"{this.eggs.Models.Count(x => x.IsDone())} eggs are done!"); <- alternative without countOfColloredEggs
            //or
            sb.AppendLine($"{countOfColoredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (IBunny bunny in this.bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
