using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TestConsole
{
    [Serializable]
    public class Error : Exception
    {
        public Error()
        {
        }

        public Error(string message) : base(message)
        {
        }

        public Error(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected Error(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
