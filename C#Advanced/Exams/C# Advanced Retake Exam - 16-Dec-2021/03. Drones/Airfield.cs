using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        //private string name;
        //private string brand;
        //private int ranre;
        //private bool available;
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public List<Drone> Drones { get; private set; }

        public int Count => this.Drones.Count;
        public string AddDrone(Drone drone)
        {

            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if (this.Drones.Count >= this.Capacity)
            {
                return "Airfield is full.";
            }
            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            int count = this.Drones.RemoveAll(x => x.Name == name);
            return count > 0;
            //if (Drones.Any(x => x.Name == name))
            //{
            //    Drones.RemoveAll(x => x.Name == name);
            //    return true;
            //}
            //return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            int count = this.Drones.RemoveAll(d => d.Brand == brand);
            return count;
            //int removedDrones = 0;
            //if (Drones.Any(x => x.Brand == brand))
            //{
            //    removedDrones = Drones.Where(x => x.Brand == brand).Count();
            //    Drones.RemoveAll(x => x.Brand == brand);
            //}
            //return removedDrones;
        }
        public Drone FlyDrone(string name)
        {
            Drone drone = this.Drones.FirstOrDefault(x => x.Name == name);
            if (drone == null)
            {
                return null;
            }
            drone.Available = false;
            return drone;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = this.Drones.Where(x => x.Range >= range).ToList();
            foreach (var item in drones)
            {
                item.Available = false;
            }
            return drones;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.Append($"Drones available at {this.Name}:{Environment.NewLine}{string.Join(Environment.NewLine, Drones.Where(x => x.Available == true))}");
            return sb.ToString();
        }
    }
}