using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Contracts
{
    public interface IBuyer
    {
        int Food { get; }

        string Name { get; }

        int Age { get; }

        void BuyFood();
    }
}
