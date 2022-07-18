using System;
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
        static void Main(string[] args)
        {
            // read initial array input
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var exceptionCount = 0;

            while (exceptionCount < 3)
            {
                // receive command
                try
                {
                    input = ExecuteCommand(input);
                }
                catch (Exception ex)
                {
                    exceptionCount++;
                }
            }

            // print out the elements of the array
        }

        public int[] ExecuteCommand(string input)
        {
            // read command from command line
            
            
            switch (command)
            {
                case "Replace":
                    
                    try
                    {

                        int index = int.Parse(commandInput[1]);
                        int element = int.Parse(commandInput[2]);
                        var modifiedArray = ExecuteReplaceCommand(index, element, input);
                        return modifiedArray;
                        
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("The variable is not in the correct format!");
                    }
                    break;

                case "Show":
                    break;

                case "Print":
                    break;
                
            }
            return new int[];
        }
        public string ParseCommand(string commandInput)
        {
            //split string return first
            return "Replace";
        }

        

        public int[] ExecuteReplaceCommand(int index, int element, int[] input)
        {
            try
            {
                input[index] = element;
            }
            catch (IndexOutOfRangeException ex)
            {
                
            }
            return new int[];
        }
    }



}
