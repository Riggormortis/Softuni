using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl.Core
{
    public class Engine
    {
        private readonly List<IIdentifiable> identifiables;


        public Engine()
        {
            this.identifiables = new List<IIdentifiable>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputTokens = input
                    .Split()
                    .ToArray();

                if (inputTokens[0] == "Citizen")
                {
                    this.AddCitizen(inputTokens);
                }
                else if (inputTokens[0] == "Pet")
                {
                    this.AddPet(inputTokens);
                }

                input = Console.ReadLine();
            }

            var birthdateAsked = Console.ReadLine();


            if (identifiables.Count == 0)
            {
                Console.WriteLine("");
            }
            else
            {
                foreach (var identifiable in this.identifiables.Where(x => x.Birthdate.EndsWith(birthdateAsked)))
                {
                    Console.WriteLine(identifiable);
                }
            }
            

        }


        private void AddCitizen(string[] inputTokens)
        {
            var name = inputTokens[1];
            var age = int.Parse(inputTokens[2]);
            var id = inputTokens[3];
            var birthdate = inputTokens[4];

            IIdentifiable citizen = new Citizen(name, age, id, birthdate);
            this.identifiables.Add(citizen);
        }

        private void AddPet(string[] inputTokens)
        {
            var name = inputTokens[1];
            var birthdate = inputTokens[2];
            

            IIdentifiable citizen = new Pet(name, birthdate);
            this.identifiables.Add(citizen);
        }

        

    }
}
