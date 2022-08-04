using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void Test_Athlete_Creation()
        {
            Athlete athlete = new Athlete("Peshkata");

            Assert.AreEqual("Peshkata", athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }

        [Test]
        public void Test_Gym_Creation()
        {
            Gym gym = new Gym("HammerGym", 15);

            Assert.AreEqual("HammerGym", gym.Name);
            Assert.AreEqual(15, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void Test_Gym_Creation_With_Null_Name_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(null, 15);
            });
        }

        [Test]
        public void Test_Gym_Creation_With_Empty_String_Name_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym("", 15);
            });
        }

        [Test]
        public void Test_Gym_Creation_With_Negative_Capacity_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Gym", -10);
            });
        }
        [Test]
        public void Test_Gym_AddAthlete_Works()
        {
          
            Gym gym = new Gym("Gym", 3);

            var athlete = new Athlete("Joro");
            var athlete1 = new Athlete("Gosho");
            

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);
            

            Assert.AreEqual(2, gym.Count);
            
        }
        [Test]
        public void Test_Gym_AddAthlete_With_Full_Capacity()
        {

            Gym gym = new Gym("Gym", 2);

            var athlete = new Athlete("Joro");
            var athlete1 = new Athlete("Gosho");
            var athlete2 = new Athlete("Pesho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete2);
            });
        }

        [Test]
        public void Test_Gym_Remove_Athlete_Works()
        {
            Gym gym = new Gym("Gym", 3);

            var athlete = new Athlete("Joro");
            var athlete1 = new Athlete("Gosho");
            
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);

            gym.RemoveAthlete(athlete.FullName);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void Test_Gym_Remove_Athlete_With_NonExistant_Athlete_Throws()
        {
            Gym gym = new Gym("Gym", 3);

            var athlete = new Athlete("Joro");
            var athlete1 = new Athlete("Gosho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Nqma takyv");
            });
        }
        [Test]
        public void Test_Gym_Injured_Athlete_Works()
        {
            Gym gym = new Gym("Gym", 3);

            var athlete = new Athlete("Joro");
            var athlete1 = new Athlete("Gosho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);

            var returnedAthlete = gym.InjureAthlete(athlete.FullName);

            Assert.AreEqual(true, athlete.IsInjured);

            Assert.AreSame(athlete, returnedAthlete);
        }

        [Test]
        public void Test_Gym_Injured_Athlete_With_NonExistant_Works()
        {
            Gym gym = new Gym("Gym", 3);

            var athlete = new Athlete("Joro");
            var athlete1 = new Athlete("Gosho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Nqma takyv");
            });
        }

        [Test]
        public void Test_Gym_Report_With_Injured_Works()
        {
            Gym gym = new Gym("Gym", 3);

            var athlete = new Athlete("Joro");
            var athlete1 = new Athlete("Gosho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);

            var returnedAthlete = gym.InjureAthlete(athlete.FullName);

            var report = gym.Report();

            Assert.AreEqual("Active athletes at Gym: Gosho", gym.Report());
        }

        [Test]
        public void Test_Gym_Report_Without_Injured_Works()
        {
            Gym gym = new Gym("Gym", 3);

            var athlete = new Athlete("Joro");
            var athlete1 = new Athlete("Gosho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);

           

            var report = gym.Report();

            Assert.AreEqual("Active athletes at Gym: Joro, Gosho", gym.Report());
        }

        [Test]
        public void Test_Gym_Empty_Report_Works()
        {
            Gym gym = new Gym("Gym", 3);

            var report = gym.Report();

            Assert.AreEqual("Active athletes at Gym: ", gym.Report());
        }
    }
}
