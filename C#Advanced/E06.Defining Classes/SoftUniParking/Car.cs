using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int HorsePower { get { return horsePower; } set { horsePower = value; } }
        public string RegistrationNumber { get { return registrationNumber; } set { registrationNumber = value; } }

        //constructor
        public Car (string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        //da prenapisha metoda ToString (obekta kato tekst), koito e vgraden metod vyv vseki klas -> {ime na proekta}.{ime na klasa}
        public override string ToString()
        {
            //"Make: {make}"
            //"Model: {model}"
            //"HorsePower: {horse power}"
            //"RegistrationNumber: {registration number}"

            StringBuilder sb = new StringBuilder();
            sb.Append($"Make: {Make}").Append(Environment.NewLine); // .Append(Environment.NewLine); <- nov red
            sb.Append($"Model: {Model}").Append(Environment.NewLine);
            sb.Append($"HorsePower: {HorsePower}").Append(Environment.NewLine);
            sb.Append($"RegistrationNumber: {RegistrationNumber}");

            return sb.ToString();
        }
    }
}
