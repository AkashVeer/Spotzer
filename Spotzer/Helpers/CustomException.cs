using System;

namespace Spotzer.Helpers
{
    public class CustomException : Exception
    {
        public CustomException() : base()
        {
        }
        public CustomException(string message) : base(message)
        {
        }
    }
}
