using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLogic.Definitions;
using NLogic.Rules;
using NLogic.Ruleset;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NLogic.Tests.Rules
{
    [TestClass]
    public class Parse
    {
        #region Fields

        private string MockDataDirectory;

        #endregion Fields

        #region Methods

        [TestMethod]
        public async Task ParseCleanRule()
        {
            var rulePath = Path.Combine(MockDataDirectory, "NRule_Clean.json");
            var ruleRaw = File.ReadAllText(rulePath);

            var rule = await NRule.ParseAsync(ruleRaw);

            Assert.IsNotNull(rule);
            Assert.IsNotNull(rule.Conditions);
            Assert.IsNotNull(rule.Actions);
        }

        [TestInitialize]
        public void SetMockDataDirectory()
        {
            var executingDirectoryPath = Directory.GetCurrentDirectory();
            var projectDirectory = Directory.GetParent(executingDirectoryPath).Parent.Parent.FullName;

            MockDataDirectory = Path.Combine(projectDirectory, "Rules", "MockData");
        }

        #endregion Methods
    }
}