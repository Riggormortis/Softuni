using System;

namespace _1._Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            if (n >= 66)
            {
                Console.WriteLine("elder");
            }
            else if (n >= 20 & n <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (n >= 14 & n <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (n >= 3 & n <= 13)
            {
                Console.WriteLine("child");
            }
            else
            {
                Console.WriteLine("baby");
            }



        }
    }
}
