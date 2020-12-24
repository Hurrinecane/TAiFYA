using System;
using System.Runtime.Serialization;

namespace MathLang
{
    [Serializable]
    internal class IntepreterException : Exception
    {
        public IntepreterException()
        {
        }

        public IntepreterException(string message) : base(message)
        {
        }

        public IntepreterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IntepreterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}