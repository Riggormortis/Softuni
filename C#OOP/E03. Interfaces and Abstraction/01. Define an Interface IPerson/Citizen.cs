using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson
    {
        private int age;
        private string name;

        public Citizen(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int Age 
        { 
            get
            {
                return this.age;   
            } 
            set
            {
                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
    }
}
