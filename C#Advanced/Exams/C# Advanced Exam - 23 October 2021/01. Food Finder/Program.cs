using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());

            var existWordList = new (string, int)[]
            {
                ("pear", 4),
                ("flour", 5),
                ("pork", 4),
                ("olive", 5),
            };
            string[] words = new string[] { "pear", "flour", "pork", "olive" };

            while (consonants.Count != 0)
            {
                string vowel = vowels.Dequeue().ToString();
                vowels.Enqueue(char.Parse(vowel));
                string consonant = consonants.Pop().ToString();
                
                for (int i = 0; i < 4; i++)
                {
                    if (existWordList[i].Item1.Contains(vowel))
                    {
                        existWordList[i].Item1 = existWordList[i].Item1.Replace(vowel, " ");
                        existWordList[i].Item2--;
                    }
                    if (existWordList[i].Item1.Contains(consonant))
                    {
                        existWordList[i].Item1 = existWordList[i].Item1.Replace(consonant, " ");
                        existWordList[i].Item2--;
                    }
                }
            }
            int wordsFound = 0;
            List<string> wordsListFound = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                if (existWordList[i].Item2 == 0)
                {
                    wordsFound++;
                    wordsListFound.Add(words[i]);
                }
            }
            Console.WriteLine($"Words found: {wordsFound}");
            wordsListFound.ForEach(Console.WriteLine);
        }
    }
}
