using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            //add
            Func<List<int>, List<int>> add = list => list.Select(number => number += 1).ToList();

            //multiply
            Func<List<int>, List<int>> multiply = list => list.Select(number => number *= 2).ToList();

            //subtract
            Func<List<int>, List<int>> subtract = list => list.Select(number => number -= 1).ToList();

            //print
            Action<List<int>> print = list => Console.WriteLine(String.Join(" ", list));

            string command = Console.ReadLine();

            while (command != "end")
            { //comand = "add", "multiply", "substract" or "print"

                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;

                    case "multiply":
                        numbers = multiply(numbers);
                        break;

                    case "subtract":
                        numbers = subtract(numbers);
                        break;

                    case "print":
                        print(numbers);
                        break;
                }


                command = Console.ReadLine();
            }
        }
    }
}
