using System;
using System.Linq;
using System.Collections.Generic;
namespace _4.Opinion_Poll
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());

            var family = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                if (age >= 30)
                {
                    Person person = new Person(name, age);

                    family.Add(person);
                }
                

            }

            var result = family
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
                

        }
    }
}
