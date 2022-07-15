namespace WildFarm.Exceptions
{
    using System;
    class InvalidFactoryTypeException: Exception
    {
        private const string DefaultMessage = "Invalid type";

        public InvalidFactoryTypeException()
        : base(DefaultMessage)
        {

        }

        public InvalidFactoryTypeException(string message)
            : base(message)
        {

        }

    } 
}
