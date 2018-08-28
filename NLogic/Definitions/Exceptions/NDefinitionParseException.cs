using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Definitions.Exceptions
{
    public class NDefinitionParseException : Exception
    {
        #region Fields

        private const string NMessage = "Failed to parse NLogic definition from source.";

        #endregion Fields

        #region Constructors

        public NDefinitionParseException()
            : base(message: NMessage)
        {
        }

        public NDefinitionParseException(string message)
            : base(message)
        {
        }

        public NDefinitionParseException(Exception innerException)
            : base(NMessage, innerException)
        {
        }

        public NDefinitionParseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Constructors
    }
}