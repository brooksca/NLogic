using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Elements.Infrastructure
{
    public interface INOperator
    {
        #region Properties

        string Name { get; }

        string[] Symbols { get; }

        Type[] ValidTypes { get; }

        #endregion Properties
    }
}