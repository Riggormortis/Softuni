using System;
using System.Linq;

namespace Generics
{
    public class StartUp
    {
        static void Main(string[] args)
        {



            // Tuple<string, int> tuple = new Tuple<string, int>("12", 2);
            string[] personInput = Console.ReadLine().Split(' ');

            string[] beerInput = Console.ReadLine().Split(' ');

            string[] numbersInput = Console.ReadLine().Split(' ');


            Tuple<string, string> personInfo = new Tuple<string, string>($"{personInput[0]} {personInput[1]}", personInput[2]);

            int liters = int.Parse(beerInput[1]);
            Tuple<string, int> beerInfo = new Tuple<string, int>(beerInput[0], liters);

            int integer = int.Parse(numbersInput[0]);
            double dbl = double.Parse(numbersInput[1]);


            Tuple<int, double> numbersInfo = new Tuple<int, double>(integer, dbl);

            Console.WriteLine(personInfo);
            Console.WriteLine(beerInfo);
            Console.WriteLine(numbersInfo);
            
            //Generics Compare
            //double n = double.Parse(Console.ReadLine());
            //Box<double> box = new Box<double>();


            //for (int i = 0; i < n; i++)
            //{
                
            //    double input = double.Parse(Console.ReadLine());
            //    box.Items.Add(input);
            //}

            

            //double value = double.Parse(Console.ReadLine());

            //double greaterElements = box.GetGreaterElementsCount(value);

            //Console.WriteLine(greaterElements);
        }
    }
}
