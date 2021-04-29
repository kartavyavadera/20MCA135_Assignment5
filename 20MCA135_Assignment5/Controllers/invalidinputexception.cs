using System;
using System.Runtime.Serialization;

namespace _20MCA135_Assignment5.Controllers
{
    [Serializable]
    internal class invalidinputexception : Exception
    {
        public invalidinputexception()
        {
        }

        public invalidinputexception(string message) : base(message)
        {
        }

        public invalidinputexception(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected invalidinputexception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}