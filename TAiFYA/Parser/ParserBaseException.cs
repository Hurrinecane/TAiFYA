using System;
using System.Runtime.Serialization;

namespace MathLang
{
    [Serializable]
    internal class ParserBaseException : Exception
    {
        public ParserBaseException()
        {
        }

        public ParserBaseException(string message) : base(message)
        {
        }

        public ParserBaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParserBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}