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

                if (inputTokens.Length == 2)
                {
                    this.AddRobot(inputTokens);
                }
                else if (inputTokens.Length == 3)
                {
                    this.AddCitizen(inputTokens);
                }

                input = Console.ReadLine();
            }

            var fakeIdDigits = Console.ReadLine();

            foreach (var identifiable in this.identifiables.Where(x => x.Id.EndsWith(fakeIdDigits)))
            {
                Console.WriteLine(identifiable);
            }

        }


        private void AddCitizen(string[] inputTokens)
        {
            var name = inputTokens[0];
            var age = int.Parse(inputTokens[1]);
            var id = inputTokens[2];

            IIdentifiable citizen = new Citizen(name, age, id);
            this.identifiables.Add(citizen);
        }

        private void AddRobot(string[] inputTokens)
        {
            var model = inputTokens[0];
            var id = inputTokens[1];

            IIdentifiable robot = new Robot(model, id);
            this.identifiables.Add(robot);
        }

    }
}
