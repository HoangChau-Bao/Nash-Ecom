using System;
using System.Globalization;

namespace Rookie.Ecom.Contracts.Exceptions
{
    public class ErrorException : Exception
    {
        public ErrorException() : base()
        {
        }

        public ErrorException(string message) : base(message)
        {
        }

        public ErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}