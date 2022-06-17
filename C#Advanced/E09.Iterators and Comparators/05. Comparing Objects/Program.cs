using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            //Collection of people
            //people [n - 1]
            //==
            //!=
            //count

            List<Person> people = new List<Person>();

            string info = Console.ReadLine();

            while (info != "END")
            {
                string[] personInfo = info.Split();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];

                Person person = new Person(name, age, town);

                people.Add(person);

                info = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());

            Person personToCompare = people[n - 1];

            int equals = 0;
            int diff = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equals++;
                }
                else
                {
                    diff++;
                }
            }

            if (equals == 1)
            {
                Console.WriteLine("No matches");
               
            }
            else
            {
                Console.WriteLine($"{equals} {diff} {people.Count}");

            }
            
        }

        
    }
}
