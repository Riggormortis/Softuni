using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private ICollection<IBooking> models;

        public BookingRepository()
        {
            models = new List<IBooking>();
        }


        public void AddNew(IBooking model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
          return  (IReadOnlyCollection<IBooking>) this.models;
        }

        public IBooking Select(string criteria)
        {
            return models.FirstOrDefault(c => c.BookingNumber.ToString() == criteria);
        }
    }
}
