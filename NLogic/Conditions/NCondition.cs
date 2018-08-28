using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLogic.Conditions.Exceptions;
using NLogic.Conditions.Infrastructure;
using NLogic.Elements;
using NLogic.Elements.Infrastructure;
using NLogic.Rules.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLogic.Conditions
{
    public class NCondition : INCondition
    {
        #region Properties

        public INOperator Operator { get; }

        public object Reference { get; }

        public INSubject Subject { get; }

        #endregion Properties

        #region Constructors

        public NCondition(INSubject subject, INOperator nOperator, object referenceValue)
        {
            Subject = subject;
            Operator = nOperator;
            Reference = referenceValue;
        }

        #endregion Constructors

        #region Methods

        public static INCondition Parse(string jsonCondition)
        {
            try
            {
                var rawCondition = JObject.Parse(jsonCondition);
                return Parse(rawCondition);
            }
            catch (JsonReaderException ex)
            {
                throw new NConditionParseException(ex);
            }
        }

        public static INCondition Parse(JToken conditionObject)
        {
            try
            {
                var subject = NSubject.Parse(conditionObject["Subject"].ToString());
                var op = NOperator.Parse(conditionObject["Operator"].ToString());
                var reference = JObject.Parse(conditionObject["Reference"].ToString());

                return new NCondition(subject, op, reference);
            }
            catch (JsonReaderException ex)
            {
                throw new NConditionParseException(ex);
            }
        }

        public static async Task<INCondition> ParseAsync(string jsonCondition)
        {
            try
            {
                var conditionObject = JObject.Parse(jsonCondition);
                return await ParseAsync(conditionObject);
            }
            catch (JsonReaderException ex)
            {
                throw new NConditionParseException(ex);
            }
        }

        public static async Task<INCondition> ParseAsync(JObject conditionObject)
        {
            try
            {
                var subject = NSubject.Parse(conditionObject["Subject"].ToString());
                var op = NOperator.Parse(conditionObject["Operator"].ToString());
                var reference = JObject.Parse(conditionObject["Reference"].ToString());

                return new NCondition(subject, op, reference);
            }
            catch (JsonReaderException ex)
            {
                throw new NConditionParseException(ex);
            }
        }

        #endregion Methods
    }
}