using System;
using System.IO;
using System.Collections.Generic;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {


            Spy spy = new Spy();
            string result = spy.AnalyzeAccessModifiers("Stealer.Hacker");

            Console.WriteLine(result);



        }
    }
}
