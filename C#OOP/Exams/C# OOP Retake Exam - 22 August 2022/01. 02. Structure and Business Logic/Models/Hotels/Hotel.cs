using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;



        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            this.rooms = new RoomRepository();
            this.bookings = new BookingRepository();
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }

                this.fullName = value;
            }
        }

        public int Category
        {
            get => category;
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }
                category = value;
            }
        }

        public double Turnover => GetTurnover();

        public IRepository<IRoom> Rooms { get => this.rooms; set => this.rooms = value; }
        public IRepository<IBooking> Bookings { get => this.bookings; set => this.bookings = value; }



        private double GetTurnover()
        {
            double total = 0;

            foreach (var booking in this.Bookings.All())
            {
                total += booking.ResidenceDuration * booking.Room.PricePerNight;
            }

            return Math.Round(total, 2);

    }

}
}
