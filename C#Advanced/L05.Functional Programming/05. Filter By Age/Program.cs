using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{

    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            
            List<Person> people = new List<Person>();
            
            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                people.Add(new Person(input[0], int.Parse(input[1])));
            }

            string filterInput = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string formatInput = Console.ReadLine();

            Func<Person, int, bool> filter = GetFilter(filterInput);
            people = people.Where(x => filter(x, ageFilter)).ToList();

            Action<Person> printer = GetPrinter(formatInput);

            people.ForEach(printer);
        }

        private static Action<Person> GetPrinter(string formatInput)
        {
            switch (formatInput)
            {
                case "name":
                    return s => Console.WriteLine(s.Name);

                case "age":
                    return s => Console.WriteLine(s.Age);

                case "name age":
                    return s => Console.WriteLine($"{s.Name} - {s.Age}");
                default:
                    return null;
            }
               

        }

        private static Func<Person, int, bool> GetFilter(string filterInput)
        {
            switch (filterInput)
            {
                case "older":
                    return (s, age) => s.Age >= age;

                case "younger":
                    return (s, age) => s.Age < age;

                default:
                    return null;
            }
        }
    }
}
