namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        [TestCase("Nemo")]
        [TestCase("Riba1")]
        [TestCase("Riba2")]
        public void TestIfConstructorSetsNameCorrectly(string name)
        {
            Fish fish = new Fish(name);

            Assert.AreEqual(fish.Name, name);
        }

        [Test]
        public void TestIfConstructorSetAvailableCorrectyl()
        {
            string expName = "Riba3";
            Fish fish = new Fish(expName);

            Assert.AreEqual(fish.Name, expName);
            Assert.IsTrue(fish.Available);
        }

        [Test]
        [TestCase("Riba1", 2)]
        [TestCase("Riba2", 10)]
        [TestCase("Riba3", 999)]
        public void TestIfConstructorWorksCorrectly(string name, int capacity)
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            Assert.AreEqual(name, aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestWithInvalidName(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 10);
            }, "Invalid aquarium name!");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-99999999)]
        [TestCase(int.MinValue)]
        public void TestWithInvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Riba1", capacity);
            }, "Invalid aquarium capacity!");
        }

        
        public void TestAddFishWithFreeCapacity()
        {
            var aquarium = new Aquarium("Akvarium", 2);

            Fish fish = new Fish("Riba");

            aquarium.Add(fish);
            int expCnt = 1;
            int actCnt = aquarium.Count;

            Assert.AreEqual(expCnt, actCnt);
        }

        [Test]
        public void TestAddFishWhenAquariumIsFull()
        {
            var aquarium = new Aquarium("Akvarium", 2);

            Fish fish = new Fish("Riba");
            Fish fish2 = new Fish("Riba2");
            Fish fish3 = new Fish("Riba3");
            aquarium.Add(fish);
            aquarium.Add(fish2);


            Assert.Throws<InvalidOperationException>(() => { aquarium.Add(fish3); }, "Aquarium is full!");
        }

        [Test]
        public void TestRemoveFishWorks()
        {
            var aquarium = new Aquarium("Akvarium", 6);

            string fToRemoveName = "Riba2";

            Fish fish = new Fish("Riba");
            Fish fish2 = new Fish("Riba2");
            Fish fish3 = new Fish("Riba3");
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            aquarium.RemoveFish(fToRemoveName);

            int expCnt = 2;
            int actCnt = aquarium.Count;

            Assert.AreEqual(expCnt, actCnt);
        }

        [Test]
        public void TestRemoveNonExistentFishWorks()
        {
            var aquarium = new Aquarium("Akvarium", 6);

            string fToRemoveName = "NonExistent";

            Fish fish = new Fish("Riba");
            Fish fish2 = new Fish("Riba2");
            Fish fish3 = new Fish("Riba3");
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            
            Assert.Throws<InvalidOperationException>(() => { aquarium.RemoveFish(fToRemoveName); }, $"Fish with the name {fToRemoveName} doesn't exist!");
            
        }

        [Test]
        public void TestSellFishWorks()
        {
            var aquarium = new Aquarium("Akvarium", 6);

            string fToSellName = "Riba2";

            Fish fish = new Fish("Riba");
            Fish fish2 = new Fish("Riba2");
            Fish fish3 = new Fish("Riba3");
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            Fish fishToSell = aquarium.SellFish(fToSellName);

            Assert.IsFalse(fishToSell.Available);
        }

        [Test]
        public void TestSellNonExistentFishWorks()
        {
            var aquarium = new Aquarium("Akvarium", 6);

            string fToSellName = "NonExistent";

            Fish fish = new Fish("Riba");
            Fish fish2 = new Fish("Riba2");
            Fish fish3 = new Fish("Riba3");
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            Assert.Throws<InvalidOperationException>(() => { aquarium.SellFish(fToSellName); }, $"Fish with the name {fToSellName} doesn't exist!");
        }

        [Test]
        public void TestReportWithManyFishes()
        {
            var aquarium = new Aquarium("Akvarium", 6);

            Fish fish = new Fish("Riba");
            Fish fish2 = new Fish("Riba2");
            Fish fish3 = new Fish("Riba3");
            aquarium.Add(fish);
            aquarium.Add(fish2);

            string actReport = aquarium.Report();
            string expReport = $"Fish available at Akvarium: Riba, Riba2";

            Assert.AreEqual(expReport, actReport);
        }

        [Test]
        public void TestReportWithOneFish()
        {
            var aquarium = new Aquarium("Akvarium", 6);

            Fish fish = new Fish("Riba");
            Fish fish2 = new Fish("Riba2");
            Fish fish3 = new Fish("Riba3");
            aquarium.Add(fish);
           

            string actReport = aquarium.Report();
            string expReport = $"Fish available at Akvarium: Riba";

            Assert.AreEqual(expReport, actReport);
        }

        [Test]
        public void TestReportWithNoFish()
        {
            var aquarium = new Aquarium("Akvarium", 6);

            Fish fish = new Fish("Riba");
            Fish fish2 = new Fish("Riba2");
            Fish fish3 = new Fish("Riba3");
            


            string actReport = aquarium.Report();
            string expReport = $"Fish available at Akvarium: ";

            Assert.AreEqual(expReport, actReport);
        }

    }
}
