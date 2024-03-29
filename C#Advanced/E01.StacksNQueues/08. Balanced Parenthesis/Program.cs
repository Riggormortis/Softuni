﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            //бр. отворени == бр. затворени
            //последната отворена трябва да съвпада с последната затворена
            string input = Console.ReadLine(); //"{[()]}"
            Stack<char> openBrackets = new Stack<char>(); //отворени скоби
            bool areBalanced = false;
            //true -> балансирани
            //false -> не са балансирани

            foreach (char bracket in input)
            {
                //проверка за отворена скоба
                if (bracket == '{' || bracket == '[' || bracket == '(')
                {
                    openBrackets.Push(bracket);
                }
                //проверка за затворена скоба
                else if (bracket == '}' || bracket == ']' || bracket == ')')
                {
                    //проверка дали имаме отворени скоби 
                    if (openBrackets.Count == 0)
                    {
                        //проверка дали имаме отворени скоби
                        areBalanced = false;
                        break;
                    }

                    //проверка дали последната отворена съвпада с текущата скоба
                    char lastOpen = openBrackets.Pop();

                    //{ и }
                    if (lastOpen == '{' && bracket == '}')
                    {
                        //баланс
                        areBalanced = true;
                    }
                    //[ и ]
                    else if (lastOpen == '[' && bracket == ']')
                    {
                        //баланс
                        areBalanced = true;
                    }
                    //( и )
                    else if (lastOpen == '(' && bracket == ')')
                    {
                        //баланс
                        areBalanced = true;
                    }
                    else
                    {
                        //последната отворена не съвпада с текущата затворена
                        areBalanced = false;
                        break;
                    }
                }
            }
            //преминали сме през всички скоби 
            //ако има баланс -> YES
            if (areBalanced)
            {
                Console.WriteLine("YES");
            }
            //ако няма баланс -> NO
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
