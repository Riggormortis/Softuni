using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Exeptions
{
    public class InvalidRadiusException : Exception
    {
        private const string ExceptionMessage = "Radius must be a positive number!";

        public InvalidRadiusException()
            : base(ExceptionMessage)
        {
        }
    }
}
