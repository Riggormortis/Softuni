using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {

            [Test]

            public void GarageNameShouldThrowExeptionWithEmptyAndNullValues()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    //Arange and Act
                    var garage = new Garage(null, 10);
                },
                //Assert
                "Invalid garage name.");

                Assert.Throws<ArgumentNullException>(() =>
                {
                    //Arange and Act
                    var garage = new Garage(string.Empty, 10);
                },
                //Assert
                "Invalid garage name.");

            }

            [Test]

            public void GarageNamePropertyShouldWorkCorrectly()
            {
                //Arange 
                var garageName = "Test";
                //Act
                var garage = new Garage(garageName, 10);

                //Assert
                Assert.That(garage.Name, Is.EqualTo(garageName));
            }

            [Test]

            public void GarageMechanicsShouldThrowExceptionWithNoMechanics()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    //Arange and Act
                    var garage = new Garage("Test", 0);
                },
               //Assert
               "At least one mechanic must work in the garage.");

                Assert.Throws<ArgumentException>(() =>
                {
                    //Arange and Act
                    var garage = new Garage("Test", -1);
                },
               //Assert
               "At least one mechanic must work in the garage.");
            }

            [Test]
            public void GarageMechanicsPropertyShouldWorkCorrectly()
            {
                //Arange 
                const int garageMechanics = 10;
                //Act
                var garage = new Garage("Test", garageMechanics);

                //Assert
                Assert.That(garage.MechanicsAvailable, Is.EqualTo(garageMechanics));
            }

            [Test]

            public void GarageAddCarShouldThrowExceptionWithNoAvailableMechanics()
            {
                var garage = new Garage("Test", 1);
                var firstCar = new Car("Mercedess", 10);
                var secondCar = new Car("Opel", 15);

                //Act
                garage.AddCar(firstCar);

                //Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    //Act
                    garage.AddCar(secondCar);
                },
               //Assert
               "No mechanic available.");
            }

            [Test]
            public void GarageAddCarShouldIncrementWithCarCountCorrectly()
            {
                var garage = new Garage("Test", 10);
                var firstCar = new Car("Mercedess", 10);
                var secondCar = new Car("Opel", 15);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);

                Assert.That(garage.CarsInGarage, Is.EqualTo(2));
            }

            [Test]

            public void  GarageFixCarsShoudThrowExceptionIfCarModelIsMissing()
            {
                //Arrange
                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedess", 10);
                var secondCar = new Car("Opel", 15);

                //Act
                Assert.Throws<InvalidOperationException > (() =>
                {
                   
                    garage.FixCar(secondCar.CarModel);
                },
               //Assert
               $"The car {secondCar.CarModel} doesn't exist.");

            }

            [Test]
            public void GarageFixCarShoudReturnFixedCarIfExist()
            {
                const string carModel = "Opel";

                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedess", 10);
                var secondCar = new Car(carModel, 15);

                //Act
                garage.AddCar(secondCar);
                var fixedCar = garage.FixCar(carModel);

                Assert.That (fixedCar.IsFixed, Is.True);
                Assert.That(fixedCar.CarModel, Is.EqualTo(carModel));
                Assert.That(fixedCar.NumberOfIssues, Is.EqualTo(0));
            }

            [Test]
            public void GarageRemoveFixedCarShouldThrowExceptionIfNoFixedCarsAreAvailable()
            {
                //Arrange
                const string carModel = "Opel";

                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedess", 10);
                var secondCar = new Car(carModel, 15);

                //Act
                Assert.Throws<InvalidOperationException>(() =>
                {

                    garage.RemoveFixedCar();
                },
               //Assert
               $"No fixed cars available.");
            }

            [Test]
            public void GarageRemoveFixedCarShouldRemoveFixedCars()
            {
                //Arrange
                const string carModel = "Opel";

                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedess", 10);
                var secondCar = new Car(carModel, 15);
                var thridCar = new Car("BMW", 50);

                //Act
                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thridCar);
                garage.FixCar(carModel);

                var fixedCars = garage.RemoveFixedCar();

                Assert.That(fixedCars, Is.EqualTo(1));
                Assert.That(garage.CarsInGarage, Is.EqualTo(2));
            }

            [Test]

            public void GarageReportShouldShowCorrectResults()
            {
                //Arrange
                const string carModel = "Opel";

                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedess", 10);
                var secondCar = new Car(carModel, 15);
                var thridCar = new Car("BMW", 50);

                //Act
                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thridCar);
                garage.FixCar(carModel);

                var report = garage.Report();

                Assert.That(report, Is.EqualTo($"There are 2 which are not fixed: Mercedess, BMW."));
            }

        }
    }
}