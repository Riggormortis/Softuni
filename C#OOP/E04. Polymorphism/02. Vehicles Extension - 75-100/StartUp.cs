using System;

namespace Vehicles
{
    using System;

    using Core;
    using Factories;
    using Factories.Interfaces;
    using Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
           
            var engine = new Engine();
            engine.Start(); //Starts business logic
        }
    }
}
