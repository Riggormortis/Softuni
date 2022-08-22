using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;
        


        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }

        public IRoom Room
        {
            get => room;
            private set
            {         
                room = value;
            }
        }

        public int ResidenceDuration
        {
            get => residenceDuration;
            private set
            {
                if (value <= 0)
                {
                   
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }

                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => adultsCount;
            private set
            {
                if (value <= 0)
                {

                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }

                this.adultsCount = value;
            }
        }
        public int ChildrenCount
        {
            get => childrenCount;
            private set
            {
                if (value < 0)
                {

                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }

                this.childrenCount = value;
            }
        }

        public int BookingNumber
        {
            get => this.bookingNumber;
            private set => this.bookingNumber = value;
        }

        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();            

            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {totalPaid:F2} $");

            return sb.ToString().TrimEnd();
        }

        public decimal totalPaid => (decimal)Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);

    }
}
