using System;
using System.Runtime.Serialization;

namespace CTIN.WebApi.Modules.System
{
    [Serializable]
    internal class Exception : global::System.Exception
    {
        public Exception()
        {
        }

        public Exception(string message) : base(message)
        {
        }

        public Exception(string message, global::System.Exception innerException) : base(message, innerException)
        {
        }

        protected Exception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}