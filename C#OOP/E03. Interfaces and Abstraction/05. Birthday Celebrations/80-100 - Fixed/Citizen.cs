using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IPerson, IIdentifiable
    {
       
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public override string ToString()
        {
            return $"{this.Birthdate}";
        }

    }
}
