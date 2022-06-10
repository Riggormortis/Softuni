using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        //fields (poleta) => haratkeristiki - name and age

        private string name;
        private int age;

            public Person() //-konstruktor po podrazbirane
        {
            //prazen obekt
            //name: null
            //age: 0
        }




        public string Name { get; set; }


        public int Age
        {
            get { return age; }
            set { age = value; }
        }


        public Person(string name, int age) //-konstruktor s parametri
        {
            this.Name = name;
            this.Age = age;
        }


        //methods (metodi)

    }
}
