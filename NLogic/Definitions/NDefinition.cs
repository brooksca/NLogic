using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLogic.Definitions.Exceptions;
using NLogic.Definitions.Infrastructure;
using NLogic.Ruleset;
using NLogic.Ruleset.Infrastructure;
using NLogic.Serilization.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLogic.Definitions
{
    public class NDefinition : INDefinition
    {
        #region Constructors

        public NDefinition(IEnumerable<INRuleset> rulesets)
        {
            Rulesets = rulesets;
        }

        #endregion Constructors

        #region Properties

        public IEnumerable<INRuleset> Rulesets { get; }

        #endregion Properties

        #region Methods

        public async Task<INDefinition> Parse(string jsonDefinition)
        {
            try
            {
                var rawDefinition = JObject.Parse(jsonDefinition);
                return await Parse(rawDefinition);
            }
            catch (JsonReaderException ex)
            {
                throw new NDefinitionParseException(ex);
            }
        }

        public async Task<INDefinition> Parse(JObject jsonObjectDefinition)
        {
            try
            {
                var rulesetsObject = jsonObjectDefinition["Definition"];
                var rulesetsRaw = JArray.Parse(rulesetsObject["Rulesets"].ToString());
                var rulesets = rulesetsRaw.Select(ruleset => NRuleset.Parse(ruleset.ToString()));
                return new NDefinition(rulesets);
            }
            catch (JsonReaderException ex)
            {
                throw new NDefinitionParseException(ex);
            }
        }

        public Task Serialize(INSerializer Serializer)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}