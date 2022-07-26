namespace ValidationAttributes.Models
{
    using Utilities;
    using ValidationAttributes.Utilities.Attributes;

    public class Person
    {
        private const int AgeMinValue = 12;
        private const int AgeMaxvalue = 90;


        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }

        [MyRange(AgeMinValue, AgeMaxvalue)]
        public int Age { get; set; }
    }
}
