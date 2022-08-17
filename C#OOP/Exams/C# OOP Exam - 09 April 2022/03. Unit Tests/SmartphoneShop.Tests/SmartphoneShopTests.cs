using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        [TestCase("Nemo")]
        [TestCase("Riba1")]
        [TestCase("Riba2")]
        public void TestIfConstructorSetsNameAndBatteryCorrectly(string name)
        {
            Smartphone phone = new Smartphone(name, 46);

            Assert.AreEqual(phone.ModelName, name);
            Assert.AreEqual(phone.MaximumBatteryCharge, 46);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-99999999)]
        [TestCase(int.MinValue)]
        public void TestShopWithInvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(capacity);
            }, "Invalid capacity.");
        }

        [Test]
        [TestCase(2)]
        [TestCase(10)]
        [TestCase(999)]
        public void TestIfShopConstructorWorksCorrectly(int capacity)
        {
            Shop shop = new Shop(capacity);
            
            Assert.AreEqual(capacity, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void TestAdd()
        {
            Shop shop = new Shop(5);

            Smartphone phone1 = new Smartphone("Iphone", 44);
            shop.Add(phone1);
            Smartphone phone2 = new Smartphone("Nokia", 99);
            shop.Add(phone2);

            Assert.AreEqual(2, shop.Count);
        }
        [Test]
        public void TestAddSamePhone()
        {
            Shop shop = new Shop(5);

            Smartphone phone1 = new Smartphone("Iphone", 44);
            shop.Add(phone1);


            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone1);
            }, "The phone model Iphone already exist.");
           
        }

        [Test]
        public void TestAddFullCapacity()
        {
            Shop shop = new Shop(2);

            Smartphone phone1 = new Smartphone("Iphone", 44);
            shop.Add(phone1);
            Smartphone phone2 = new Smartphone("Nokia", 99);
            shop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone2);
            }, "The shop is full.");
        }


        [Test]
        public void TestRemove()
        {
            Shop shop = new Shop(5);

            Smartphone phone1 = new Smartphone("Iphone", 44);
            shop.Add(phone1);
            Smartphone phone2 = new Smartphone("Nokia", 99);
            shop.Add(phone2);

            shop.Remove(phone1.ModelName);

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void TestRemoveNonExistentPhone()
        {
            Shop shop = new Shop(5);

            Smartphone phone1 = new Smartphone("Iphone", 44);
            shop.Add(phone1);
            Smartphone phone2 = new Smartphone("Nokia", 99);
            shop.Add(phone2);

            

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Nonexistent");
            }, "The phone model Nonexistent doesn't exist.");
        }

        [Test]
        public void TestTestPhoneNonExistentPhone()
        {
            Shop shop = new Shop(5);

            Smartphone phone1 = new Smartphone("Iphone", 44);
            shop.Add(phone1);
            Smartphone phone2 = new Smartphone("Nokia", 99);
            shop.Add(phone2);



            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Nonexistent", 14);
            }, "The phone model Nonexistent doesn't exist.");
        }

        [Test]
        public void TestTestPhoneLowBatteryPhone()
        {
            Shop shop = new Shop(5);

            Smartphone phone1 = new Smartphone("Iphone", 14);
            shop.Add(phone1);
            Smartphone phone2 = new Smartphone("Nokia", 99);
            shop.Add(phone2);



            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(phone1.ModelName, 15);
            }, $"The phone model {phone1.ModelName} is low on batery.");
        }

        [Test]
        public void TestTestPhoneWorksCorrectly()
        {
            Shop shop = new Shop(5);

            Smartphone phone1 = new Smartphone("Iphone", 14);
            shop.Add(phone1);
            Smartphone phone2 = new Smartphone("Nokia", 95);
            shop.Add(phone2);

            shop.TestPhone(phone2.ModelName, 15);

            Assert.AreEqual(phone2.CurrentBateryCharge, 80);
        }

        [Test]
        public void TestChargePhoneNonExistentPhone()
        {
            Shop shop = new Shop(5);

            Smartphone phone1 = new Smartphone("Iphone", 44);
            shop.Add(phone1);
            Smartphone phone2 = new Smartphone("Nokia", 99);
            shop.Add(phone2);

            shop.TestPhone(phone2.ModelName, 15);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Nonexistent");
            }, "The phone model Nonexistent doesn't exist.");
        }

        [Test]
        public void TestChargePhoneWorksCorrectly()
        {
            Shop shop = new Shop(5);

            Smartphone phone1 = new Smartphone("Iphone", 44);
            shop.Add(phone1);
            Smartphone phone2 = new Smartphone("Nokia", 99);
            shop.Add(phone2);

            shop.TestPhone(phone1.ModelName, 15);


            shop.ChargePhone(phone1.ModelName);

            Assert.AreEqual(phone1.CurrentBateryCharge, 44);
        }
    }
}