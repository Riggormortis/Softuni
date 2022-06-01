using System;
using System.Collections.Generic;
namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            //n -> length of set1
            //m - > length of set2
            //" 3 4".Split(' ') -> ["3", "4"]
            string input = Console.ReadLine(); //"4 3"
            int n = int.Parse(input.Split(' ')[0]);
            int m = int.Parse(input.Split(' ')[1]);

            HashSet<int> firstSet = new HashSet<int>(); //set1
            for (int i = 1; i <= n; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }
            
            HashSet<int> secondSet = new HashSet<int>(); //set1
            for (int i = 1; i <= m; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondSet);
            //firstSet -> 1,3,5,7
            //secondSet -> 3, 4, 5 
            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
