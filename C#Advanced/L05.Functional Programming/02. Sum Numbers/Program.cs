﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> evenNumbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(evenNumbers.Count);
            Console.WriteLine(evenNumbers.Sum());
        }
    }
}
