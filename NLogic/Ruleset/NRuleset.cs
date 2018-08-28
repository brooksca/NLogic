using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLogic.Rules;
using NLogic.Rules.Infrastructure;
using NLogic.Ruleset.Exceptions;
using NLogic.Ruleset.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLogic.Ruleset
{
    public class NRuleset : INRuleset
    {
        #region Constructors

        public NRuleset(IEnumerable<INRule> rules, Union union)
        {
            Rules = rules;
            Union = union;
        }

        #endregion Constructors

        #region Properties

        public IEnumerable<INRule> Rules { get; }

        public Union Union { get; }

        #endregion Properties

        #region Methods

        public static INRuleset Parse(string jsonRuleset)
        {
            try
            {
                var rulesetObject = JObject.Parse(jsonRuleset);
                return Parse(rulesetObject);
            }
            catch (JsonReaderException ex)
            {
                throw new NRulesetParseException(ex);
            }
        }

        public static INRuleset Parse(JObject rulesetObject)
        {
            try
            {
                var rawRules = JArray.Parse(rulesetObject["Rules"].ToString());

                var rules = rawRules.Select(rule => NRule.Parse(rule.ToString()));
                var union = rulesetObject["Union"].ToString();

                return new NRuleset(rules, (Union)Enum.Parse(typeof(Union), union));
            }
            catch (JsonReaderException ex)
            {
                throw new NRulesetParseException(ex);
            }
        }

        public static async Task<INRuleset> ParseAsync(string jsonRuleset)
        {
            try
            {
                var rulesetObject = JObject.Parse(jsonRuleset);
                return await ParseAsync(rulesetObject);
            }
            catch (JsonReaderException ex)
            {
                throw new NRulesetParseException(ex);
            }
        }

        public static async Task<INRuleset> ParseAsync(JObject rulesetObject)
        {
            try
            {
                var rawRules = JArray.Parse(rulesetObject["Rules"].ToString());

                var rules = rawRules.Select(rule => NRule.Parse(rule.ToString()));
                var union = rulesetObject["Union"].ToString();

                return new NRuleset(rules, (Union)Enum.Parse(typeof(Union), union));
            }
            catch (JsonReaderException ex)
            {
                throw new NRulesetParseException(ex);
            }
        }

        #endregion Methods
    }
}