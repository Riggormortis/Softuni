using System;
using System.IO;
namespace _06._Split__Merge_Binary_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            int bytes = 1;
            Console.WriteLine("How many parts do you want?");
            int n = int.Parse(Console.ReadLine());
            using (FileStream stream = new FileStream("../../../text.txt", FileMode.Open))
            {
                long fileLenght = (long)stream.Length / n;

                for (int i = 0; i < n; i++)
                {
                    using (FileStream newFile = new FileStream($"../../../text{i}.txt", FileMode.CreateNew))
                    {
                        var data = new byte[bytes];
                        stream.Read(data, 0, data.Length);

                        newFile.Write(data, 0, data.Length);
                    }
                }
            }
        }
    }
}
