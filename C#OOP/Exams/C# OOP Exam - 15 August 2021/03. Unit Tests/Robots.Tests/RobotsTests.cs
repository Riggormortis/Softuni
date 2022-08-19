namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    public class RobotsTests
    {
        [Test]
        [TestCase("Nemo")]
        [TestCase("Riba1")]
        [TestCase("Riba2")]
        public void TestIfConstructorSetsNameAndBatteryCorrectly(string name)
        {
            Robot robot = new Robot(name, 46);

            Assert.AreEqual(robot.Name, name);
            Assert.AreEqual(robot.MaximumBattery, 46);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-99999999)]
        [TestCase(int.MinValue)]
        public void TestRobotManagerWithInvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager manager = new RobotManager(capacity);
            }, "Invalid capacity!");
        }

        [Test]
        [TestCase(2)]
        [TestCase(10)]
        [TestCase(999)]
        public void TestRobotManagerConstructorWorksCorrectly(int capacity)
        {
            RobotManager manager = new RobotManager(capacity);

            Assert.AreEqual(capacity, manager.Capacity);
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void TestAdd()
        {
            RobotManager manager = new RobotManager(5);

            Robot robot1 = new Robot("Iphone", 44);
            manager.Add(robot1);
            Robot robot2 = new Robot("Nokia", 99);
            manager.Add(robot2);

            Assert.AreEqual(2, manager.Count);
        }

        [Test]
        public void TestAddSameRobot()
        {
            RobotManager manager = new RobotManager(5);

            Robot robot1 = new Robot("Iphone", 44);
            manager.Add(robot1);


            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robot1);
            }, $"There is already a robot with name {robot1.Name}!");

        }

        [Test]
        public void TestAddFullCapacity()
        {
            RobotManager manager = new RobotManager(2);

            Robot robot1 = new Robot("Iphone", 44);
            manager.Add(robot1);
            Robot robot2 = new Robot("Nokia", 99);
            manager.Add(robot2);
            Robot robot3 = new Robot("Roboto", 99);
            

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robot3);
            }, "Not enough capacity!");
        }

        [Test]
        public void TestRemove()
        {
            RobotManager manager = new RobotManager(5);

            Robot robot1 = new Robot("Iphone", 44);
            manager.Add(robot1);
            Robot robot2 = new Robot("Nokia", 99);
            manager.Add(robot2);
            Robot robot3 = new Robot("Roboto", 99);

            manager.Remove(robot1.Name);

            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void TestRemoveNonExistentRobot()
        {
            RobotManager manager = new RobotManager(5);

            Robot robot1 = new Robot("Iphone", 44);
            manager.Add(robot1);
            Robot robot2 = new Robot("Nokia", 99);
            manager.Add(robot2);
            Robot robot3 = new Robot("Roboto", 99);
            manager.Add(robot3);


            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Remove("Nonexistent");
            }, $"Robot with the name Nonexistent doesn't exist!");
        }

        [Test]
        public void TestWorkNonExistentRobot()
        {
            RobotManager manager = new RobotManager(5);

            Robot robot1 = new Robot("Iphone", 44);
            manager.Add(robot1);
            Robot robot2 = new Robot("Nokia", 99);
            manager.Add(robot2);
            Robot robot3 = new Robot("Roboto", 99);
            manager.Add(robot3);



            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("Nonexistent", "Plowing", 14);
            }, $"Robot with the name Nonexistent doesn't exist!");
        }

        [Test]
        public void TestWorkLowBatter()
        {
            RobotManager manager = new RobotManager(5);

            Robot robot1 = new Robot("Iphone", 44);
            manager.Add(robot1);
            Robot robot2 = new Robot("Nokia", 99);
            manager.Add(robot2);
            Robot robot3 = new Robot("Roboto", 99);
            manager.Add(robot3);



            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work(robot1.Name, "job", 46);
            }, $"{robot1.Name} doesn't have enough battery!");
        }

        [Test]
        public void TestWorkWorksCorrectly()
        {
            RobotManager manager = new RobotManager(5);

            Robot robot1 = new Robot("Iphone", 44);
            manager.Add(robot1);
            Robot robot2 = new Robot("Nokia", 99);
            manager.Add(robot2);
            Robot robot3 = new Robot("Roboto", 99);
            manager.Add(robot3);

            manager.Work(robot1.Name, "job", 14);

            Assert.AreEqual(robot1.Battery, 30);
        }

        [Test]
        public void TestChargeNonExistent()
        {
            RobotManager manager = new RobotManager(5);

            Robot robot1 = new Robot("Iphone", 44);
            manager.Add(robot1);
            Robot robot2 = new Robot("Nokia", 99);
            manager.Add(robot2);
            Robot robot3 = new Robot("Roboto", 99);
            manager.Add(robot3);

            manager.Work(robot1.Name, "job", 14);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Charge("Nonexistent");
            }, $"Robot with the name {robot1.Name} doesn't exist!");
        }

        [Test]
        public void TestChargePhoneWorksCorrectly()
        {
            RobotManager manager = new RobotManager(5);

            Robot robot1 = new Robot("Iphone", 44);
            manager.Add(robot1);
            Robot robot2 = new Robot("Nokia", 99);
            manager.Add(robot2);
            Robot robot3 = new Robot("Roboto", 99);
            manager.Add(robot3);

            manager.Work(robot1.Name, "job", 14);


            manager.Charge(robot1.Name);

            Assert.AreEqual(robot1.Battery, robot1.MaximumBattery);
        }

    }
}
