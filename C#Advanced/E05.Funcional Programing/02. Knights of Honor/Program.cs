using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            //Func<name, modified name>
            Func<string, string> addPrefix = name => "Sir " + name;

            foreach (string name in names)
            {
                Console.WriteLine(addPrefix(name));
            }
        }
    }
}
