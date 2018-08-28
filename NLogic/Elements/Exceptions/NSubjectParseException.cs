using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Elements.Exceptions
{
    public class NSubjectParseException : Exception
    {
        #region Fields

        private const string NMessage = "Failed to parse NLogic subject from source.";

        #endregion Fields

        #region Constructors

        public NSubjectParseException()
            : base(NMessage)
        {
        }

        public NSubjectParseException(string message)
            : base(message)
        {
        }

        public NSubjectParseException(Exception innerException)
            : base(message: NMessage, innerException: innerException)
        {
        }

        public NSubjectParseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Constructors
    }
}