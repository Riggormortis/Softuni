using System;

namespace DemoEnumerations
{
    class Program
    {
        static void Main(string[] args)
        {
            CarState carState = (CarState)3;

            Console.WriteLine(carState);

            Console.WriteLine((CarState)2);


            //other example
            DateTime date = DateTime.Now;

            DayOfWeek dayOfWeek = date.DayOfWeek;


            Console.WriteLine(dayOfWeek);
        }
    }

    
}
