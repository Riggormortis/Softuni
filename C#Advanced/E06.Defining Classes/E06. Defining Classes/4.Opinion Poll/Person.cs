using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Opinion_Poll
{
    public class Person
    {

        
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }


        public int Age { get; set; }

        public string Name { get; set; }

        
    }
}


