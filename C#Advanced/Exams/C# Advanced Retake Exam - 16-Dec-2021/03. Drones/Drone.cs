using System.Text;
using System;
namespace Drones
{
    public class Drone
    {

        private string name;
        private string brand;
        private int range;
        private bool available;
        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
            this.Available = true;
        }
        public string Name { get { return name; } set { name = value; } }
        public string Brand { get { return brand; } set { brand = value; } }
        public int Range { get { return range; } set { range = value; } }
        public bool Available { get { return available; } set { available = value; } }

        public override string ToString()
        {

            var result = new StringBuilder();
            result.AppendLine($"Drone: {this.name}");
            result.AppendLine($"Manufactured by: {this.brand}");
            result.AppendLine($"Range: {this.range} kilometers");

            return result.ToString().TrimEnd();
            // return $"Drone: {this.Name + Environment.NewLine}Manufactured by: {this.Brand + Environment.NewLine}Range: {Range} kilometers";
        }
    }
}
