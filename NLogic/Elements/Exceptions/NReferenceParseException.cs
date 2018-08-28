using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Elements.Exceptions
{
    public class NReferenceParseException : Exception
    {
        #region Fields

        private const string NMessage = "Failed to parse NLogic reference from source.";

        #endregion Fields

        #region Constructors

        public NReferenceParseException()
            : base(NMessage)
        {
        }

        public NReferenceParseException(string message)
            : base(message)
        {
        }

        public NReferenceParseException(Exception innerException)
            : base(NMessage, innerException)
        {
        }

        public NReferenceParseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Constructors
    }
}