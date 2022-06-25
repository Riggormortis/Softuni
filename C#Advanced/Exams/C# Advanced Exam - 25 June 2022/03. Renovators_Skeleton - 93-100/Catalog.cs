using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators = new List<Renovator>();
        private string name;
        private int neededRenovators;
        private string project;

        public List<Renovator> Renovators { get => renovators; set => renovators = value; }
        public string Name { get => name; set => name = value; }
        public int NeededRenovators { get => neededRenovators; set => neededRenovators = value; }
        public string Project { get => project; set => project = value; }
        
        public int Count => this.Renovators.Count;

        

        public Catalog(string name, int neededRenovators, string project)
        {

            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            
        }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (Renovators.Count == NeededRenovators)
            {
                
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            else
            {
                Renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            var renovator = this.renovators.FirstOrDefault(e => e.Name == name);
            if (renovator != null)
            {
                return this.renovators.Remove(renovator);
            }
            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            var residentRenovators = this.renovators.Where(renovator => !renovator.Type.Equals(type)).ToList();
            int removedRenovators = this.renovators.Count - residentRenovators.Count;
            this.renovators = residentRenovators;
            return removedRenovators;
        }

        public Renovator HireRenovator(string name)
        {
            var renovator = this.renovators.FirstOrDefault(e => e.Name == name);
            if (renovator != null)
            {
                renovator.Hired = true;
                return renovator;
            }
            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovators = Renovators.Where(x => x.Days == days).ToList();

            return renovators;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {project}:");

            foreach (var item in Renovators.Where(x => x.Hired == false))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();

        }
    }
}
