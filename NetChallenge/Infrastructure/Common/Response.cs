using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Infrastructure.Common
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }

        public Response()
        {
            IsSuccess = true;
            Errors = new List<string>();
        }

        public void AddError(string errorMessage)
        {
            IsSuccess = false;
            Errors.Add(errorMessage);
        }
    }
}
