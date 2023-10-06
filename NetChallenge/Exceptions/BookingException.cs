using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    public class BookingException : Exception
    {
        public BookingException(string message) : base(message)
        {
        }
    }
}
