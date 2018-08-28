using NLogic.Elements.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Conditions.Infrastructure
{
    public interface INCondition
    {
        #region Properties

        INOperator Operator { get; }

        object Reference { get; }

        INSubject Subject { get; }

        #endregion Properties
    }
}