namespace AquaShop.Models.Aquariums
{

    public class FreshwaterAquarium : Aquarium
    {
        private const int FreshWaterAquariumInitialCapacity = 50;

        public FreshwaterAquarium(string name)
            : base(name, FreshWaterAquariumInitialCapacity)
        {

        }

    }
}
