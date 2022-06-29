namespace MergeFiles
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            string[] firstContent = File.ReadAllLines(firstInputFilePath);
            string[] secondContent = File.ReadAllLines(secondInputFilePath);

            
                StringBuilder mergedContent = new StringBuilder();

            for (int i = 0; i < Math.Min(firstContent.Length, secondContent.Length); i++)
            {
                mergedContent.AppendLine($"{firstContent[i]}");
                mergedContent.AppendLine($"{secondContent[i]}");
            }

            if (firstContent.Length > secondContent.Length)
            {
                mergedContent.AppendLine(string.Join(Environment.NewLine, firstContent.Skip(secondContent.Length)));
            }

            if (secondContent.Length > firstContent.Length)
            {
                mergedContent.AppendLine(string.Join(Environment.NewLine, secondContent.Skip(firstContent.Length)));
            }
                        
            File.WriteAllText(outputFilePath, mergedContent.ToString());
      


        }
    }
}
