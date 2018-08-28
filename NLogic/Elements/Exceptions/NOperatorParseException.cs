using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Elements.Exceptions
{
    public class NOperatorParseException : Exception
    {
        #region Fields

        private const string NMessage = "Failed to parse NLogic operator from source.";

        #endregion Fields

        #region Constructors

        public NOperatorParseException()
            : base(NMessage)
        {
        }

        public NOperatorParseException(string message)
            : base(message)
        {
        }

        public NOperatorParseException(Exception innerException)
            : base(NMessage, innerException)
        {
        }

        public NOperatorParseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Constructors
    }
}