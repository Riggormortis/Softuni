using System;

namespace DemoStatic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Painter painter = new Painter();
            //  painter.PrintRectangle();
            // painter.PrintTriangle(); // ne raboti

            // Painter.PrintTriangle(); //raboti

            Console.WriteLine(MathClass.CalculateArea(5,6));



        }
    }

    class Painter
    {
        public Painter()
        {
            Size = 4;
        }

        public int Size { get; set; }

        public static void PrintTriangle() //<- kogato e static otiva na samiq klas, a ne na obekta
        {
            Console.WriteLine("Printing Triangle");
        }

        public void PrintRectangle()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine("Printing Rectangle");
            }
        }

    }
}
