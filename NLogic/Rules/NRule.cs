using Newtonsoft.Json.Linq;
using NLogic.Conditions;
using NLogic.Conditions.Infrastructure;
using NLogic.Rules.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLogic.Rules
{
    public class NRule : INRule
    {
        #region Properties

        public IEnumerable<INAction> Actions { get; }

        public IEnumerable<INCondition> Conditions { get; }

        #endregion Properties

        #region Constructors

        public NRule(IEnumerable<INCondition> conditions, IEnumerable<INAction> actions)
        {
            Actions = actions;
            Conditions = conditions;
        }

        #endregion Constructors

        #region Methods

        public static INRule Parse(JObject ruleObject)
        {
            var conditionsRaw = JArray.Parse(ruleObject["Conditions"].ToString());
            var actionsRaw = JArray.Parse(ruleObject["Actions"].ToString());

            var conditions = conditionsRaw.Select(condition => NCondition.Parse(condition.ToString()));
            var actions = actionsRaw.Select(action => NAction.Parse(action.ToString()));

            return new NRule(conditions, actions);
        }

        public static INRule Parse(string jsonRule)
        {
            var ruleObject = JObject.Parse(jsonRule);
            return Parse(ruleObject);
        }

        public static async Task<INRule> ParseAsync(JObject ruleObject)
        {
            var conditionsRaw = JArray.Parse(ruleObject["Conditions"].ToString());
            var actionsRaw = JArray.Parse(ruleObject["Actions"].ToString());

            var conditions = conditionsRaw.Select(condition => NCondition.Parse(condition.ToString()));
            var actions = actionsRaw.Select(action => NAction.Parse(action.ToString()));

            return new NRule(conditions, actions);
        }

        public static async Task<INRule> ParseAsync(string jsonRule)
        {
            var ruleObject = JObject.Parse(jsonRule);
            return await ParseAsync(ruleObject);
        }

        #endregion Methods
    }
}