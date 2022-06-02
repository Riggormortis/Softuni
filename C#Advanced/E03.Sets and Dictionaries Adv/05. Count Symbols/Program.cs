using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var charCount = new Dictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var character in input)
            {
                if (!charCount.ContainsKey(character))
                {
                    charCount[character] = 1;
                }
                else
                {
                    charCount[character]++;
                }
            }

            foreach (var kvp in charCount.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
