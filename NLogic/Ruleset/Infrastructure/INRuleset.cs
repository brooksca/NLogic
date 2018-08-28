using NLogic.Rules.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Ruleset.Infrastructure
{
    public interface INRuleset
    {
        #region Properties

        IEnumerable<INRule> Rules { get; }

        Union Union { get; }

        #endregion Properties
    }
}