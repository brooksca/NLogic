using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Conditions.Exceptions
{
    public class NConditionParseException : Exception
    {
        #region Fields

        private const string NMessage = "Failed to parse NLogic condition from source.";

        #endregion Fields

        #region Constructors

        public NConditionParseException()
            : base(message: NMessage)
        {
        }

        public NConditionParseException(string message)
            : base(message)
        {
        }

        public NConditionParseException(Exception innerException)
            : base(message: NMessage, innerException: innerException)
        {
        }

        public NConditionParseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Constructors
    }
}