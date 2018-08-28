using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Elements.Exceptions
{
    public class NOperatorNotFoundBySymbolException : Exception
    {
        #region Fields

        private const string NMessage = "Failed to extract an NLogic operator with the symbol \"{0}\".";

        #endregion Fields

        #region Constructors

        public NOperatorNotFoundBySymbolException(string symbol)
            : base(string.Format(NMessage, symbol))
        {
        }

        public NOperatorNotFoundBySymbolException(string symbol, Exception innerException)
            : base(string.Format(NMessage, symbol), innerException)
        {
        }

        #endregion Constructors
    }
}