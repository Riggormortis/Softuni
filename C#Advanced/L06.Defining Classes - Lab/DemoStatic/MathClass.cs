using System;
using System.Collections.Generic;
using System.Text;

namespace DemoStatic
{
    public static class MathClass
    {
        //public void Print() <- dont work - static class cant have and instance
        //{

        //}

        public static int CalculateArea(int a, int b)
        {
            return a * b;
        }
    }
}
