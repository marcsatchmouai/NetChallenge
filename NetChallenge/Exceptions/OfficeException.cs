using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Exceptions
{
    public class OfficeException : Exception
    {
        public OfficeException(string message) : base(message)
        {
        }
    }
}
