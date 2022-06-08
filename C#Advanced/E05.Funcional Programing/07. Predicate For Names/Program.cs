using System;
using System.Collections.Generic;
using System.Linq;
namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> newList = new List<string>();

            Predicate<string> nameLenght = name => name.Length <= n;

            foreach (var name in names)
            {
                if (nameLenght(name))
                {
                    newList.Add(name);
                }
                
            }


            foreach (var name in newList)
            {
                Console.WriteLine(name);
            }
                 


        }
    }
}
