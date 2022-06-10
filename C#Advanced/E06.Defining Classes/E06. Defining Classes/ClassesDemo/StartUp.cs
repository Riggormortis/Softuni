using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person person = new Person("Peter", 20);

            Person person1 = new Person();

            person1.Name = "George";
            person1.Age = 18;

            Person person2 = new Person();

            person2.Name = name;
            person2.Age = age;



        }
    }
}
