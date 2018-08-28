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
    public class NSubject : INSubject
    {
        #region Properties

        public string Path { get; }

        public Type SubjectType { get; }

        #endregion Properties

        #region Constructors

        public NSubject(string path, Type subjectType)
        {
            Path = path;
            SubjectType = subjectType;
        }

        #endregion Constructors

        #region Methods

        public static NSubject Parse(string rawSubject)
        {
            try
            {
                var subjectObject = JObject.Parse(rawSubject);
                return Parse(subjectObject);
            }
            catch (JsonReaderException ex)
            {
                throw new NSubjectParseException(ex);
            }
        }

        public static NSubject Parse(JObject subjectObject)
        {
            try
            {
                var path = subjectObject["Path"].ToString();
                var type = Type.GetType(subjectObject["SubjectType"].ToString());

                return new NSubject(path, type);
            }
            catch (JsonReaderException ex)
            {
                throw new NSubjectParseException(ex);
            }
        }

        public static async Task<NSubject> ParseAsync(string rawSubject)
        {
            try
            {
                var subjectObject = JObject.Parse(rawSubject);
                return await ParseAsync(subjectObject);
            }
            catch (JsonReaderException ex)
            {
                throw new NSubjectParseException(ex);
            }
        }

        public static async Task<NSubject> ParseAsync(JObject subjectObject)
        {
            try
            {
                var path = subjectObject["Path"].ToString();
                var type = Type.GetType(subjectObject["SubjectType"].ToString());

                return new NSubject(path, type);
            }
            catch (JsonReaderException ex)
            {
                throw new NSubjectParseException(ex);
            }
        }

        #endregion Methods
    }
}