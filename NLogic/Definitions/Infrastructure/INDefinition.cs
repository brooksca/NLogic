using NLogic.Ruleset.Infrastructure;
using NLogic.Serilization.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NLogic.Definitions.Infrastructure
{
    public interface INDefinition
    {
        #region Properties

        IEnumerable<INRuleset> Rulesets { get; }

        #endregion Properties

        #region Methods

        Task<INDefinition> Parse(string jsonDefinition);

        Task Serialize(INSerializer Serializer);

        #endregion Methods
    }
}