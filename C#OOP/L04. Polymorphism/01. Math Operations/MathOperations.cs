﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public class MathOperations : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b, double c)
        {
            return a + b + c;
        }

        public decimal Add(decimal a, decimal b, decimal c)
        {
            return a + b + c;
        }
    }
}
