using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NLogic.Ruleset.Exceptions
{
    public class NRulesetParseException : Exception
    {
        #region Fields

        private const string NMessage = "Failed to parse NLogic ruleset from source.";

        #endregion Fields

        #region Constructors

        public NRulesetParseException()
            : base(message: NMessage)
        {
        }

        public NRulesetParseException(string message)
            : base(message)
        {
        }

        public NRulesetParseException(Exception innerException)
            : base(message: NMessage, innerException: innerException)
        {
        }

        public NRulesetParseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Constructors
    }
}