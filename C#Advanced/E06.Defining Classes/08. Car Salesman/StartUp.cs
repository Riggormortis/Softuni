using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine();
                engine.Model = tokens[0];
                engine.Power = int.Parse(tokens[1]);
                if (tokens.Length == 3)
                {
                    int displacement = 0;
                    bool isDigits = int.TryParse(tokens[2], out displacement);
                    if (isDigits)
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = tokens[2];
                    }
                }
                else if (tokens.Length == 4)
                {
                    engine.Displacement = int.Parse(tokens[2]);
                    engine.Efficiency = tokens[3];
                }
                engines.Add(engine);
            }
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car();
                car.Model = tokens[0];
                car.Engine = engines.First(x => x.Model == tokens[1]);
                if (tokens.Length == 3)
                {
                    int weight = 0;
                    bool isDigits = int.TryParse(tokens[2], out weight);
                    if (isDigits)
                    {
                        car.Weght = weight;
                    }
                    else
                    {
                        car.Color = tokens[2];
                    }
                }
                else if (tokens.Length == 4)
                {
                    car.Weght = int.Parse(tokens[2]);
                    car.Color = tokens[3];
                }
                cars.Add(car);
            }

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Model}:");
                Console.WriteLine($"  {item.Engine.Model}:");
                Console.WriteLine($"    Power: {item.Engine.Power}");
                if (item.Engine.Displacement != 0)
                {
                    Console.WriteLine($"    Displacement: {item.Engine.Displacement}");
                }
                else
                {
                    Console.WriteLine($"    Displacement: n/a");
                }
                if (item.Engine.Efficiency != string.Empty)
                {
                    Console.WriteLine($"    Efficiency: {item.Engine.Efficiency}");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: n/a");
                }
                if (item.Weght != 0)
                {
                    Console.WriteLine($"  Weight: {item.Weght}");
                }
                else
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                if (item.Color != string.Empty)
                {
                    Console.WriteLine($"  Color: {item.Color}");
                }
                else
                {
                    Console.WriteLine($"  Color: n/a");
                }
            }
        }
    }
}
