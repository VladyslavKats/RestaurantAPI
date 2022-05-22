using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Restaurant.BLL
{
    [Serializable]
    public class RestaurantException : Exception
    {
        public RestaurantException()
        {
        }

        public RestaurantException(string message) : base(message)
        {
        }

        public RestaurantException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RestaurantException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
