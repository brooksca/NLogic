using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLogic.Elements.Exceptions;
using NLogic.Elements.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLogic.Elements
{
    public class NReference : INReference
    {
        #region Constructors

        public NReference(string value, Type type)
        {
            Type = type;
            Value = value;
        }

        #endregion Constructors

        #region Properties

        public Type Type { get; }

        public string Value { get; }

        #endregion Properties

        #region Methods

        public static INReference Parse(string rawReference)
        {
            try
            {
                var referenceObject = JObject.Parse(rawReference);
                return Parse(referenceObject);
            }
            catch (JsonReaderException ex)
            {
                throw new NReferenceParseException(ex);
            }
        }

        public static INReference Parse(JObject referenceObject)
        {
            var rawType = string.Empty;
            try
            {
                var value = referenceObject["Value"].ToString();
                rawType = referenceObject["Type"].ToString();
                var type = Type.GetType(rawType);

                return new NReference(value, type);
            }
            catch (JsonReaderException ex)
            {
                throw new NReferenceParseException(ex);
            }
            catch (TypeLoadException ex)
            {
                throw new NReferenceInvalidTypeException(rawType, ex);
            }
        }

        public static async Task<INReference> ParseAsync(string rawReference)
        {
            try
            {
                var referenceObject = JObject.Parse(rawReference);
                return await ParseAsync(referenceObject);
            }
            catch (JsonReaderException ex)
            {
                throw new NReferenceParseException(ex);
            }
        }

        public static async Task<INReference> ParseAsync(JObject referenceObject)
        {
            var rawType = string.Empty;
            try
            {
                var value = referenceObject["Value"].ToString();
                rawType = referenceObject["Type"].ToString();
                var type = Type.GetType(rawType);

                return new NReference(value, type);
            }
            catch (JsonReaderException ex)
            {
                throw new NReferenceParseException(ex);
            }
            catch (TypeLoadException ex)
            {
                throw new NReferenceInvalidTypeException(rawType, ex);
            }
        }

        #endregion Methods
    }
}