using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Play_Catch
{
    internal class Program
    {

        /*
        You will receive on the first line an array of integers. After that you will receive commands, which should manipulate the array:
        •	"Replace {index} {element}" – Replace the element at the given index with the given element. 
        •	"Print {startIndex} {endIndex}" – Print the elements from the start index to the end index inclusive.
        •	"Show {index}" – Print the element at the index.
        You have the task to rewrite the messages from the exceptions which can be produced from your program:
        •	If you receive an index, which does not exist in the array print:
        "The index does not exist!"
        •	If you receive a variable, which is of invalid type:
        "The variable is not in the correct format!"
         When you catch 3 exceptions – stop the input and print the elements of the array separated with ", ".

        */
        static void Main()
        {
            const int TargetCountOfExceptions = 3;

            int[] numbers = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int countOfCoughtExceptions = 0;

            while (countOfCoughtExceptions < TargetCountOfExceptions)
            {
                string[] commandInfo = Console.ReadLine().Split(' ');

                string command = commandInfo[0];

                try
                {
                    if (command == "Replace")
                    {
                        string index = commandInfo[1];
                        string element = commandInfo[2];

                        Replace(numbers, index, element);
                    }
                    else if (command == "Print")
                    {
                        string startIndex = commandInfo[1];
                        string endIndex = commandInfo[2];

                        Print(numbers, startIndex, endIndex);
                    }
                    else if (command == "Show")
                    {
                        string index = commandInfo[1];

                        Show(numbers, index);
                    }
                }
                catch (FormatException)
                {
                    countOfCoughtExceptions++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    countOfCoughtExceptions++;
                    Console.WriteLine("The index does not exist!");
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        private static void Show(int[] numbers, string indexAsString)
        {
            bool isIndexInteger = int.TryParse(indexAsString, out int index);

            if (!isIndexInteger)
            {
                throw new FormatException();
            }

            if (index < 0 || index >= numbers.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine(numbers[index]);
        }

        private static void Print(int[] numbers, string startIndexAsString, string endIndexAsString)
        {
            bool isStartIndexInteger = int.TryParse(startIndexAsString, out int startIndex);
            bool isEndIndexInteger = int.TryParse(endIndexAsString, out int endIndex);

            if (!isStartIndexInteger || !isEndIndexInteger)
            {
                throw new FormatException();
            }

            if (startIndex < 0 || endIndex >= numbers.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            List<int> elementsForPrinting = new List<int>(0);

            for (int i = startIndex; i <= endIndex; i++)
            {
                elementsForPrinting.Add(numbers[i]);
            }

            Console.WriteLine(String.Join(", ", elementsForPrinting));
        }

        private static void Replace(int[] numbers, string indexAsString, string elementAsString)
        {
            bool isIndexInteger = int.TryParse(indexAsString, out int index);
            bool isElementInteger = int.TryParse(elementAsString, out int element);

            if (!isIndexInteger || !isElementInteger)
            {
                throw new FormatException();
            }

            if (index < 0 || index >= numbers.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            numbers[index] = element;
        }
    }
}
