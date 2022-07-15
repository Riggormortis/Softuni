using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TruckFuelConsumptionIncrement = 1.6;
        private const double RefuelCoeffiecient = 0.95;

        public Truck(
            double fuelQuantity,
            double fuelConsumption,
            int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double FuelConsumptionModifier
            => TruckFuelConsumptionIncrement;

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new NegativeFuelException();
            }

            if (liters + this.FuelQuantity > this.TankCapacity)
            {
                throw new FuelOutOfTankException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters * RefuelCoeffiecient;
        }
    }
}
