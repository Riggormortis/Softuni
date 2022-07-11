using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Exeptions
{
    public class InvalidSideException : Exception
    {
        public InvalidSideException(string message)
            : base(message)
        {
        }
    }
}
