using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry entry;
        [SetUp]
        public void Setup()
        {
            entry = new RaceEntry();
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionIfUnitDriverIsNull()
        {
            UnitDriver driver = null;
            Assert.Throws<InvalidOperationException>(() => entry.AddDriver(driver));
        }

        [Test]
        public void AddDriverMethodShouldPutCorrectMessageAndCounter()
        {
            UnitDriver driver = new UnitDriver("Johny", new UnitCar("Honda", 150, 40));

            Assert.AreEqual($"Driver Johny added in race.", entry.AddDriver(driver));

            Assert.AreEqual(1, entry.Counter);
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionIfDriverAlreadyExists()
        {
            UnitDriver driver = new UnitDriver("Johny", new UnitCar("Honda", 150, 40));

            entry.AddDriver(driver);
                   
            Assert.Throws<InvalidOperationException>(() => entry.AddDriver(driver));
        }

        [Test]
        public void CalculateHorsePowerShouldThrowExceptionIfLessThanMinRacers()
        {
            UnitDriver driver = new UnitDriver("Johny", new UnitCar("Honda", 150, 40));

            entry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => entry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateHorsePowerShouldWorkCorrectly()
        {
            UnitDriver driver = new UnitDriver("Johny", new UnitCar("Honda", 150, 40));
            UnitDriver driver2 = new UnitDriver("Billy", new UnitCar("McLaren", 250, 60));
            entry.AddDriver(driver);
            entry.AddDriver(driver2);

            Assert.AreEqual(200, entry.CalculateAverageHorsePower());
        }
    }
}