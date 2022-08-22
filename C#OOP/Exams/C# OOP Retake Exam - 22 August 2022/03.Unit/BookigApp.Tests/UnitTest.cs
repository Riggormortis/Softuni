using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private const int BedCapacity = 2;
        private const double PricePerNight = 10.10;
        
        

        private const string FullName = "Gencho Penchev";
        private const int Category = 3;
        //private const double turnover = 0;

        private Room room;

        private Hotel hotel;


        [SetUp]
        public void Setup()
        {
            this.room = new Room(BedCapacity, PricePerNight);
            this.hotel = new Hotel(FullName, Category);
        }

        [Test]
        public void Constructor_Room_ThrowsException_WhenBedCapacityNegative()
        {
            int bedCapacity = -2;

            Assert.That(() => new Room(bedCapacity, PricePerNight), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_Room_ThrowsException_WhenPriceNegative()
        {
            double pricePerNight = -2;

            Assert.That(() => new Room(BedCapacity, pricePerNight), Throws.ArgumentException);
        }

        [Test]
        public void Valid_Room_Ctor()
        {
            Assert.That(this.room.BedCapacity, Is.EqualTo(BedCapacity));
            Assert.That(this.room.PricePerNight, Is.EqualTo(PricePerNight));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Constructor_Hotel_ThrowsException_WhenFullNameNullOrWhiteSpace(string fullName)
        {
           

            Assert.That(() => new Hotel(fullName, Category), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(10)]
        public void Constructor_Hotel_ThrowsException_WhenCategoryIncorect(int category)
        {


            Assert.That(() => new Hotel(FullName, category), Throws.ArgumentException);
        }

        [Test]
        public void Valid_Hotel_Ctor()
        {
            Assert.That(this.hotel.FullName, Is.EqualTo(FullName));
            Assert.That(this.hotel.Category, Is.EqualTo(Category));
            Assert.That(this.hotel.Rooms.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddRoom_Works()
        {
            var hotel1 = new Hotel(FullName, Category);

            Assert.That(this.hotel.Rooms.Count, Is.EqualTo(0));
            var room = new Room(BedCapacity, Category);
            hotel1.AddRoom(room);

            Assert.That(hotel1.Rooms.Count, Is.EqualTo(1));
        }

        [Test]
        public void BookRoom_ThrowsExceptionNegativeAdults()
        {
            var hotel1 = new Hotel(FullName, Category);

            
            var room = new Room(BedCapacity, Category);
            var room1 = new Room(4, 5);
            hotel1.AddRoom(room);
            hotel1.AddRoom(room1);
           
            Assert.That(() => hotel1.BookRoom(-1, 1, 2, 20), Throws.ArgumentException);         
        }
        [Test]
        public void BookRoom_ThrowsExceptionNegativeChildren()
        {
            var hotel1 = new Hotel(FullName, Category);


            var room = new Room(BedCapacity, Category);
            var room1 = new Room(4, 5);
            hotel1.AddRoom(room);
            hotel1.AddRoom(room1);

            Assert.That(() => hotel1.BookRoom(1, -1, 2, 20), Throws.ArgumentException);
        }
        [Test]
        public void BookRoom_ThrowsExceptionNegativeStay()
        {
            var hotel1 = new Hotel(FullName, Category);


            var room = new Room(BedCapacity, Category);
            var room1 = new Room(4, 5);
            hotel1.AddRoom(room);
            hotel1.AddRoom(room1);

            Assert.That(() => hotel1.BookRoom(1, 1, -1, 20), Throws.ArgumentException);
        }

        
        [Test]
        public void BookRoom_WorksCorrectly()
        {
            var hotel1 = new Hotel(FullName, Category);


            var room = new Room(BedCapacity, Category);
            var room1 = new Room(4, 5);
            hotel1.AddRoom(room);
            hotel1.AddRoom(room1);
            hotel1.BookRoom(2, 1, 3, 200);

            Assert.That(hotel1.Bookings.Count, Is.EqualTo(1));
            Assert.That(hotel1.Turnover, Is.EqualTo(15));
        }



    }
}