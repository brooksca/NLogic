using NLogic.Conditions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLogic.Rules.Infrastructure
{
    public interface INRule
    {
        #region Properties

        IEnumerable<INAction> Actions { get; }

        IEnumerable<INCondition> Conditions { get; }

        #endregion Properties
    }
}