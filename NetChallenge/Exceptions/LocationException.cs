using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    public class LocationException : Exception
    {
        public LocationException(string message) : base(message)
        {
        }
    }
}
