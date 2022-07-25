using System;

namespace PhotoScope.Core.Exceptions
{
    /// <summary>
    /// Exception class for incorrect search parameter
    /// </summary>
    public class IncorrectParameterException : Exception
    {
        public IncorrectParameterException(string message):base(message)
        {
            
        }
    }
}
