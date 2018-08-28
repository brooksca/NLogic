using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLogic.Elements.Exceptions;
using NLogic.Elements.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLogic.Elements
{
    public class NOperator : INOperator
    {
        #region Constructors

        private NOperator(string name, string[] symbols, Type[] validTypes)
        {
            Name = name;
            Symbols = symbols;
            ValidTypes = validTypes;
        }

        #endregion Constructors

        #region Properties

        public string Name { get; }

        public string[] Symbols { get; }

        public Type[] ValidTypes { get; }

        #endregion Properties

        #region Methods

        public static INOperator Parse(string rawOperator)
        {
            try
            {
                var operatorObject = JObject.Parse(rawOperator);
                return Parse(operatorObject);
            }
            catch (JsonReaderException ex)
            {
                throw new NOperatorParseException(ex);
            }
        }

        public static INOperator Parse(JObject operatorObject)
        {
            try
            {
                if (operatorObject.Property("Name") != null)
                {
                    var operatorName = operatorObject.Property("Name").Value;
                    return MapNameToOperator(operatorName.ToString());
                }

                if (operatorObject.Property("Symbol") != null)
                {
                    var operatorSymbol = operatorObject.Property("Symbol").Value;
                    return MapSymbolToOperator(operatorSymbol.ToString());
                }

                throw new NOperatorParseException();
            }
            catch (JsonReaderException ex)
            {
                throw new NOperatorParseException(ex);
            }
        }

        public static async Task<INOperator> ParseAsync(string rawOperator)
        {
            try
            {
                var operatorObject = JObject.Parse(rawOperator);
                return await ParseAsync(operatorObject);
            }
            catch (JsonReaderException ex)
            {
                throw new NOperatorParseException(ex);
            }
        }

        public static async Task<INOperator> ParseAsync(JObject operatorObject)
        {
            try
            {
                if (operatorObject.Property("Name") != null)
                {
                    var operatorName = operatorObject.Property("Name").Value;
                    return MapNameToOperator(operatorName.ToString());
                }

                if (operatorObject.Property("Symbol") != null)
                {
                    var operatorSymbol = operatorObject.Property("Symbol").Value;
                    return MapSymbolToOperator(operatorSymbol.ToString());
                }

                throw new NOperatorParseException();
            }
            catch (JsonReaderException ex)
            {
                throw new NOperatorParseException(ex);
            }
        }

        private static INOperator MapNameToOperator(string name)
        {
            // Get all the constant properties of the NOperator class so that each can be iterated
            // Taken from https://stackoverflow.com/a/10261848
            var constants = typeof(NOperator).GetFields(
                BindingFlags.Public
                | BindingFlags.Static
                | BindingFlags.FlattenHierarchy)
                .Where(constant =>
                    constant.IsLiteral
                    && !constant.IsInitOnly)
                .ToList();

            foreach (var constant in constants)
            {
                var nOperator = (INOperator)constant.GetRawConstantValue();

                if (nOperator.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    return nOperator;
            }

            // No operator found
            throw new NOperatorNotFoundByNameException(name);
        }

        private static INOperator MapSymbolToOperator(string symbol)
        {
            // Get all the constant properties of the NOperator class so that each can be iterated
            // Taken from https://stackoverflow.com/a/10261848
            var constants = typeof(NOperator).GetFields(
                BindingFlags.Public
                | BindingFlags.Static
                | BindingFlags.FlattenHierarchy)
                .Where(constant =>
                    constant.IsLiteral
                    && !constant.IsInitOnly)
                .ToList();

            foreach (var constant in constants)
            {
                var nOperator = (INOperator)constant.GetRawConstantValue();

                if (nOperator.Symbols.Contains(symbol))
                    return nOperator;
            }

            // No operator found
            throw new NOperatorNotFoundBySymbolException(symbol);
        }

        #endregion Methods

        #region Fields

        public static INOperator Equal = new NOperator(
            "Equals",
            new string[]{
                "=",
                "==",
                "===",
                "eq",
                "equals"
            },
            new Type[] {
                typeof(string),
                typeof(short),
                typeof(int),
                typeof(long),
                typeof(bool),
                typeof(char)
            });

        #endregion Fields
    }
}