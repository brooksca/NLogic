using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Elements.Exceptions
{
    public class NReferenceInvalidTypeException : Exception
    {
        #region Fields

        private const string NMessage = "\"{0}\" is not a valid type.";

        #endregion Fields

        #region Constructors

        public NReferenceInvalidTypeException(string type)
            : base(string.Format(NMessage, type))
        {
        }

        public NReferenceInvalidTypeException(string type, Exception innerException)
            : base(string.Format(NMessage, type), innerException)
        {
        }

        #endregion Constructors
    }
}