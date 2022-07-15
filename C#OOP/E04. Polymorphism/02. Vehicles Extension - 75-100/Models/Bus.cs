

namespace Vehicles.Models
{
    using Vehicles.Models.Interfaces;

    public class Bus : Vehicle, IBus
    {
        private const double BusFuelConsumptionIncrement = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double FuelConsumptionModifier
            => BusFuelConsumptionIncrement;

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= BusFuelConsumptionIncrement;
            return base.Drive(distance);
        }
    }
}
