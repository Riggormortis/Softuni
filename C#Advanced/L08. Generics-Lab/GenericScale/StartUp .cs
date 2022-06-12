using System;

namespace GenericScale
{
    class Program
    {
        static void Main(string[] args)
        {
            var scale = new EqualityScale<string>("5", "5");
            Console.WriteLine(scale.AreEqual());
        }
    }
}
