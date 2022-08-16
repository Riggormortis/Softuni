using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {

            private const string WeaponName = "Some name";
            private const double WeaponPrice = 10.10;
            private const int WeaponDestructionLevel = 3;

            private const string PlanetName = "Earth";
            private const double PlanetBudget = 10000;

            private Weapon weapon;

            private Planet planet;

            [SetUp]
            public void Setup()
            {

                this.weapon = new Weapon(WeaponName, WeaponPrice, WeaponDestructionLevel);
                this.planet = new Planet(PlanetName, PlanetBudget);
            }

            [Test]
            public void Constructor_Weapons_ThrowsException_WhenPriceIsNegative()
            {
                double price = -2;

                Assert.That(() => new Weapon(WeaponName, price, WeaponDestructionLevel), Throws.ArgumentException);
            }

            [Test]
            public void TestDestructionLevelIncrease()
            {
                Assert.AreEqual(3, weapon.DestructionLevel);

                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(4, weapon.DestructionLevel);


            }
            [Test]
            public void TestIsNuclear()
            {
                Weapon weapon1 = new Weapon("Sas", 1.11, 9);
                Weapon weapon2 = new Weapon("MIG", 5.55, 6);
                weapon1.IncreaseDestructionLevel();
                weapon2.IncreaseDestructionLevel();
                Assert.IsTrue(weapon1.IsNuclear);
                Assert.IsFalse(weapon2.IsNuclear);
            }

            [Test]
            public void Constructor_Weapon_WorksCorrectly_WhenDataIsValid()
            {
                Assert.That(this.weapon.Name, Is.EqualTo(WeaponName));
                Assert.That(this.weapon.Price, Is.EqualTo(WeaponPrice));
                Assert.That(this.weapon.DestructionLevel, Is.EqualTo(WeaponDestructionLevel));
            }


            //[Test]
            //public void Test_Planet()
            //{


            //    planet.AddWeapon(weapon);

            //    Assert.AreEqual(1, planet.Weapons.Count);
            //}


            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void Constructor_Planet_ThrowsException_WhenNameIsNullOrEmpty(string name)
            {
                Assert.That(() => new Planet(name, PlanetBudget), Throws.ArgumentException, "Invalid planet Name");
            }

            [Test]
            public void Constructor_Planet_ThrowsException_WhenBudgetIsNegative()
            {
                double budget = -2;

                Assert.That(() => new Planet(PlanetName, budget), Throws.ArgumentException, "Budget cannot drop below Zero!");
            }

            [Test]
            public void Constructor_Planet_WorksCorrectly_WhenDataIsValid()
            {
                Assert.That(this.planet.Name, Is.EqualTo(PlanetName));
                Assert.That(this.planet.Budget, Is.EqualTo(PlanetBudget));
                Assert.That(this.planet.Weapons.Count, Is.Zero);
            }

            [Test]
            public void Planet_Profit()
            {
                Assert.That(this.planet.Budget, Is.EqualTo(PlanetBudget));

                double amount = 2;

                planet.Profit(amount);

                Assert.That(this.planet.Budget, Is.EqualTo(PlanetBudget + 2));

            }

            [Test]
            public void Planet_SpendFundsThrowsException()
            {
                Assert.That(this.planet.Budget, Is.EqualTo(PlanetBudget));


                double bigAmount = 10002;

                Assert.That(() => planet.SpendFunds(bigAmount), Throws.InvalidOperationException, "Not enough funds to finalize the deal.");
            }

            [Test]
            public void Planet_SpendFundsWorksCorrectly()
            {
                Assert.That(this.planet.Budget, Is.EqualTo(PlanetBudget));

                double amount = 2;

                planet.SpendFunds(amount);

                Assert.That(this.planet.Budget, Is.EqualTo(PlanetBudget - 2));
            }

            [Test]
            public void Planet_AddWeaponThrowsException()
            {
                planet.AddWeapon(weapon);
                Weapon weapon1 = new Weapon("Some name", 1.11, 9);

                Assert.That(() => planet.AddWeapon(weapon1), Throws.InvalidOperationException, $"There is already a {weapon1.Name} weapon.");

            }

            [Test]
            public void Planet_AddWeapon_WorksCorrectly()
            {
                Assert.That(this.planet.Weapons.Count, Is.EqualTo(0));

                planet.AddWeapon(weapon);

                Assert.That(this.planet.Weapons.Count, Is.EqualTo(1));
            }

            [Test]
            public void Planet_RemoveWeapon_WorksCorrectly()
            {
                planet.AddWeapon(weapon);
                Assert.That(this.planet.Weapons.Count, Is.EqualTo(1));

                planet.RemoveWeapon("Some name");

                Assert.That(this.planet.Weapons.Count, Is.EqualTo(0));
            }

            [Test]
            public void Planet_UpgradeWeapon_ThrowsException()
            {
                planet.AddWeapon(weapon);

                string nonExistentWeapon = "No name";

                Assert.That(() => planet.UpgradeWeapon(nonExistentWeapon), Throws.InvalidOperationException, $"{nonExistentWeapon} does not exist in the weapon repository of {this.planet.Name}");


            }

            [Test]
            public void Planet_UpgradeWeapon_Works()
            {
                planet.AddWeapon(weapon);

                Assert.That(this.weapon.DestructionLevel, Is.EqualTo(3));

                planet.UpgradeWeapon(weapon.Name);

                Assert.That(this.weapon.DestructionLevel, Is.EqualTo(4));

            }

            [Test]
            public void Planet_DestructOpponent_ThrowsException()
            {
                Planet planet2 = new Planet("Mars", 1000);
                Weapon weapon1 = new Weapon("Sas", 1.11, 9);
                Weapon weapon2 = new Weapon("MIG", 5.55, 6);

                planet2.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);

                planet.AddWeapon(weapon);

                Assert.That(() => planet.DestructOpponent(planet2), Throws.InvalidOperationException, $"{planet2.Name} is too strong to declare war to!");

            }

            [Test]
            public void Planet_DestructOpponent_WorksCorrectly()
            {
                Planet planet2 = new Planet("Mars", 1000);
                Weapon weapon1 = new Weapon("Sas", 1.11, 9);
                Weapon weapon2 = new Weapon("MIG", 5.55, 6);

                planet2.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);

                planet.AddWeapon(weapon);

                string expectedResult = $"{planet.Name} is destructed!";

                string result = planet2.DestructOpponent(planet);

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}
