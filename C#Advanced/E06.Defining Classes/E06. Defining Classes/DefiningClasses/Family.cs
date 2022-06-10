using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        //field (характеристики)
        private List<Person> familyMembers;

        //constructor
        public Family()
        {
            familyMembers = new List<Person>();
        }
        

        //methods

        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            int maxAge = familyMembers.Max(member => member.Age);
            return familyMembers.First(member => member.Age == maxAge);
        }
    }
}
