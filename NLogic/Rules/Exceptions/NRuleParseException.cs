using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Rules.Exceptions
{
    public class NRuleParseException : Exception
    {
        #region Fields

        private const string NMessage = "Failed to parse NLogic rule from source.";

        #endregion Fields

        #region Constructors

        public NRuleParseException()
            : base(message: NMessage)
        {
        }

        public NRuleParseException(string message)
            : base(message)
        {
        }

        public NRuleParseException(Exception innerException)
            : base(message: NMessage, innerException: innerException)
        {
        }

        public NRuleParseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Constructors
    }
}