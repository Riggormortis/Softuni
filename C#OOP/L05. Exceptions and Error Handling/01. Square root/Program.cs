using System;
using System.Runtime.Serialization;

namespace SquareRoot
{
    internal class Program
    {

        static void Main(string[] args)
        {

            try
            {

                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                double result = Math.Sqrt(number);
                Console.WriteLine(result);
            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid number.");
            }

            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid number.");
            }

            finally
            {
                Console.WriteLine("Goodbye.");
            }

        }
    }
}
