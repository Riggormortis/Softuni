using BookingApp.Core.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BookingApp.Models.Bookings;

namespace BookingApp.Core
{
    public class Controller : IController
    {

        
        private HotelRepository hotels;
        

        public Controller()
        {
            
            hotels = new HotelRepository();
           
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.Select(hotelName) != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HotelAlreadyRegistered, hotelName));
            }

            Hotel hotel = new Hotel(hotelName, category);

            hotels.AddNew(hotel);
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            {
                var hotel = hotels.Select(hotelName);

                if (hotel == null)
                {
                    throw new InvalidOperationException(string.Format(OutputMessages.HotelNameInvalid, hotelName));
                }

                foreach (IRoom addedRoom in hotel.Rooms.All())
                {
                    if (addedRoom.GetType().Name == roomTypeName)
                    {
                        throw new InvalidOperationException(string.Format(OutputMessages.RoomTypeAlreadyCreated));
                    }
                }

                Room room = roomTypeName switch
                {
                    nameof(Apartment) => new Apartment(),
                    nameof(DoubleBed) => new DoubleBed(),
                    nameof(Studio) => new Studio(),
                    _ => throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect)
                };

                hotel.Rooms.AddNew(room);

                return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
            }
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            var hotel = hotels.Select(hotelName);
            

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            var room = hotel.Rooms.Select(roomTypeName);
      
                if (room == null)
                {
                    return string.Format(OutputMessages.RoomTypeNotCreated);
                }


                if (room.PricePerNight > 0)
                {

                throw new ArgumentException(ExceptionMessages.PriceAlreadySet);
                }
                
            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);

        }


        public string BookAvailableRoom(int adults, int children, int duration, int category)
            {
            var orderedHotels = hotels.All().Where(x => x.Category == category);

                              
            if (orderedHotels == null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            var orderHotel = orderedHotels.OrderBy(x => x.FullName);
           

            foreach (var h in orderHotel.Where(x => x.Rooms.All().Any(y => y.PricePerNight > 0)))
            {
                foreach (var r in h.Rooms.All().OrderBy(x => x.BedCapacity))
                {
                    if (r.BedCapacity >= adults + children)
                    {
                        int bNum = h.Bookings.All().Count;
                        bNum++;
                        var book = new Booking(r, duration, adults, children, bNum);
                        h.Bookings.AddNew(book);

                        return String.Format(OutputMessages.BookingSuccessful, bNum, h.FullName);
                    }
                }
            }

            return OutputMessages.RoomNotAppropriate;
        }

        public string HotelReport(string hotelName)
        {
            var h = this.hotels.Select(hotelName);
            if (h == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {h.FullName}");
            sb.AppendLine($"--{h.Category} star hotel");
            sb.AppendLine($"--Turnover: {h.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (h.Bookings.All().Any())
            {
                foreach (var b in h.Bookings.All())
                {
                    sb.AppendLine(b.BookingSummary());
                    sb.AppendLine();
                }
            }
            else
            {
                sb.AppendLine("none");
            }

            return sb.ToString().TrimEnd();
        }
    


        




            

            

        
    }
}
