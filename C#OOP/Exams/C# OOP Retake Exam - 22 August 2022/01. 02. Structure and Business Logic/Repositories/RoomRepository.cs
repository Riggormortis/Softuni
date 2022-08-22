using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private ICollection<IRoom> models;

        public RoomRepository()
        {
            models = new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            models.Add(model);
        }

        public IRoom Select(string criteria)
        {
            return models.FirstOrDefault(c => c.GetType().Name == criteria);
        }

        public IReadOnlyCollection<IRoom> All()
        => (IReadOnlyCollection<IRoom>)this.models;


    }
}
