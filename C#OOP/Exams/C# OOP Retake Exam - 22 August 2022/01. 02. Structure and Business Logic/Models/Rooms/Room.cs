using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {

        private int bedCapacity;
        private double price;

        public Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
            PricePerNight = 0;
        }


        public int BedCapacity { get => this.bedCapacity; protected set => this.bedCapacity = value; }

        public double PricePerNight 
        {
            get => this.price;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
