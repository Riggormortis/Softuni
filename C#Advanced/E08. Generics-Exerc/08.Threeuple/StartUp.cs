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


            Tuple<string, string, string> personInfo = new Tuple<string, string, string>($"{personInput[0]} {personInput[1]}", personInput[2], personInput[3]);

            int liters = int.Parse(beerInput[1]);
            bool drunk = beerInput[2] == "drunk";
            Tuple<string, int, bool> beerInfo = new Tuple<string, int, bool>(beerInput[0], liters, drunk);

            string namePerson = numbersInput[0];
            double dbl = double.Parse(numbersInput[1]);
            string nameBank = numbersInput[2];

            Tuple<string, double, string> numbersInfo = new Tuple<string, double, string>(namePerson, dbl, nameBank);

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
