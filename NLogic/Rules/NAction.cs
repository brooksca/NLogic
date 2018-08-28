using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLogic.Rules.Exceptions;
using NLogic.Rules.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLogic.Rules
{
    public class NAction : INAction
    {
        #region Methods

        public async Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Methods

        public static INAction Parse(string rawAction)
        {
            try
            {
                var actionObject = JObject.Parse(rawAction);
                return Parse(actionObject);
            }
            catch (JsonReaderException ex)
            {
                throw new NRuleParseException(ex);
            }
        }

        public static INAction Parse(JObject actionObject)
        {
            throw new NotImplementedException();
        }

        public static async Task<INAction> ParseAsync(JObject actionObject)
        {
            throw new NotImplementedException();
        }

        public static async Task<INAction> ParseAsync(string rawAction)
        {
            try
            {
                var actionObject = JObject.Parse(rawAction);
                return await ParseAsync(actionObject);
            }
            catch (JsonReaderException ex)
            {
                throw new NRuleParseException(ex);
            }
        }
    }
}