namespace ValidationAttributes
{
    using System;
    using ValidationAttributes.Models;
    using Utilities;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 null, //"Pesho" <- Valid
                 -1 //33 <- Valid
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
