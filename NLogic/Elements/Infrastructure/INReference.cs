using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Elements.Infrastructure
{
    public interface INReference
    {
        #region Properties

        Type Type { get; }
        string Value { get; }

        #endregion Properties
    }
}