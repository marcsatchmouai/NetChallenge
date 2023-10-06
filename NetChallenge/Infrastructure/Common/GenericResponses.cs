using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Infrastructure.Common
{
    public class GenericResponses<T> : Response
    {
        
        public List<T> Data { get; set; }
        

        public GenericResponses()
        {
            Data = new List<T>();
        }

        public GenericResponses<T> AddData(T item)
        {
            Data.Add(item);
            return this;
        }

        public GenericResponses<T> AddData(IEnumerable<T> items)
        {
            Data.AddRange(items);
            return this;
        }
    }
}
