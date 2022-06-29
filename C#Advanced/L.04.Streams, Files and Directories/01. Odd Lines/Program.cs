using System;
using System.IO;
namespace _01._Odd_Lines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            string path = "01. Odd Lines";
            string fileName = "input.txt";
            string filePath = Path.Combine(path, fileName);

            using (var reader = new StreamReader(filePath))
            {
                using (var writer = new StreamWriter("Output.txt"))
                {
                    int count = 0;

                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        if (count % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        count++;

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}

