using System;
using System.Linq;

namespace Generics
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();


            for (int i = 0; i < n; i++)
            {
                
                double input = double.Parse(Console.ReadLine());
                box.Items.Add(input);
            }

            

            double value = double.Parse(Console.ReadLine());

            double greaterElements = box.GetGreaterElementsCount(value);

            Console.WriteLine(greaterElements);
        }
    }
}
