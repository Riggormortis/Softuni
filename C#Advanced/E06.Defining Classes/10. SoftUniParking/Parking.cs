using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {
        //fields - > harakteristiki
        private List<Car> cars;
        private int capacity;

        //property na poletata

        public List<Car> Cars { get { return cars; } set { cars = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }

        public int Count { get { return Cars.Count; } }

        //constructor
        public Parking (int capacity)
        {
            //new object
            //cars = null
            //capacity = 0
            Cars = new List<Car>();
            Capacity = capacity;
        }

        //metodi

        public string AddCar(Car addedCar)
        {
            bool canAddCar = true;
            //1. Car to be on the parking
            foreach (Car car in Cars)
            {


                if (car.RegistrationNumber == addedCar.RegistrationNumber)
                {
                    canAddCar = false;
                    return "Car with that registration number, already exists!";

                }
            }
                //2. Is there space on the parking
                if (Cars.Count + 1 > Capacity)
                {
                    canAddCar = false;
                    return "Parking is full!";
                   
                }
                //3. Add the car in the parking - if 1 and 2 pass
                if (canAddCar)
                {
                    Cars.Add(addedCar);
                    return $"Successfully added new car {addedCar.Make} {addedCar.RegistrationNumber}";
                }
            return "";
            
        }

        public string RemoveCar (string registrationNumber) //premahva kola ot parkinga po reg.nomer
        {
            bool isAvailable = false;
            //1. is the car on the parking
            foreach (Car car in Cars)
            {
                if (car.RegistrationNumber == registrationNumber)
                {
                    isAvailable = true;
                }
            }

            if (!isAvailable)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car carToRemove = Cars.First(car => car.RegistrationNumber == registrationNumber);
                Cars.Remove(carToRemove);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars.First(car => car.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                RemoveCar(registrationNumber);
            }
        }
    }
}
