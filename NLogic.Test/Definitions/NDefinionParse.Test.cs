using System.IO;
using NLogic.Defintions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NLogic.Test
{
    [TestClass]
    public class NDefinitionParse
    {
        [TestMethod]
        public async Task ParseSampleJsonFileTest()
        {
            // Load the test data
            var definitionRaw = File.ReadAllText("~/Mock/DefinitionSample_Clean.json");
            var definition = NDefinition.Parse(definitionRaw);
        }
    }
}