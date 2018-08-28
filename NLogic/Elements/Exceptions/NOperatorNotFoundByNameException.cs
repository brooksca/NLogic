using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Elements.Exceptions
{
    public class NOperatorNotFoundByNameException : Exception
    {
        #region Fields

        private const string NMessage = "Failed to extract an NLogic operator with the name \"{0}\".";

        #endregion Fields

        #region Constructors

        public NOperatorNotFoundByNameException(string name)
            : base(string.Format(NMessage, name))
        {
        }

        public NOperatorNotFoundByNameException(string name, Exception innerException)
            : base(string.Format(NMessage, name), innerException)
        {
        }

        #endregion Constructors
    }
}