namespace Vehicles.Models
{
    using Interfaces;
    using Vehicles.Exceptions;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        private Vehicle()
        {
            this.FuelConsumptionModifier = 0;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : this()
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public int TankCapacity { get; protected set; }

        //Full property -> Open to extension, easy can add validation
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                this.fuelConsumption = value + this.FuelConsumptionModifier;
            }
        }

        protected virtual double FuelConsumptionModifier { get; }

      

        public string Drive(double distance)
        {
            var vehicleType = this.GetType().Name;

            double fuelNeeded = distance * this.FuelConsumption;
            if (fuelNeeded > this.FuelQuantity)
            {
                //Not Enough fuel
                throw new LowFuelException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new NegativeFuelException();
            }

            if (liters + this.FuelQuantity > this.TankCapacity)
            {
                throw new FuelOutOfTankException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }

            

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
