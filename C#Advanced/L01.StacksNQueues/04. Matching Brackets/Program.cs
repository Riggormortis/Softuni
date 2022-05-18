using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {

            string expression = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                if (expression[i] == ')')
                {
                    int startIndex = stack.Pop();
                    int endIndex = i+1;
                    Console.WriteLine(expression.Substring(startIndex, endIndex - startIndex));
                }
            }


        }
    }
}
