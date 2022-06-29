using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            string token = string.Empty;
            List<Trainer> trainers = new List<Trainer>();

            while ((token = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = token.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = trainers.FirstOrDefault(x => x.Name == trainerName);
                if (trainer != null)
                {
                    trainer.CollectionOfPokemon.Add(pokemon);
                }
                else
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    newTrainer.CollectionOfPokemon.Add(pokemon);
                    trainers.Add(newTrainer);
                }
            }

            while ((token = Console.ReadLine()) != "End")
            {
                for (int i = 0; i < trainers.Count; i++)
                {
                    if (trainers[i].CollectionOfPokemon.Any(x => x.Element == token))
                    {
                        trainers[i].NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainers[i].CollectionOfPokemon)
                        {
                            pokemon.ReduceHealth();
                        }
                        trainers[i].CollectionOfPokemon.RemoveAll(x => x.Health <= 0);
                    }
                }
            }
            foreach (var item in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{item.Name} {item.NumberOfBadges} {item.CollectionOfPokemon.Count}");
            }
        }
    }
}
