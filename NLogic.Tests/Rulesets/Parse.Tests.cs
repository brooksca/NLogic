using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLogic.Definitions;
using NLogic.Ruleset;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NLogic.Tests.Rulesets
{
    [TestClass]
    public class Parse
    {
        #region Fields

        private string MockDataDirectory;

        #endregion Fields

        #region Methods

        [TestMethod]
        public async Task ParseCleanRuleset()
        {
            var rulesetPath = Path.Combine(MockDataDirectory, "NRuleset_Clean.json");
            var rulesetRaw = File.ReadAllText(rulesetPath);

            var ruleset = await NRuleset.ParseAsync(rulesetRaw);

            Assert.IsNotNull(ruleset);
            Assert.IsNotNull(ruleset.Rules);
        }

        [TestInitialize]
        public void SetMockDataDirectory()
        {
            var executingDirectoryPath = Directory.GetCurrentDirectory();
            var projectDirectory = Directory.GetParent(executingDirectoryPath).Parent.Parent.FullName;

            MockDataDirectory = Path.Combine(projectDirectory, "Rulesets", "MockData");
        }

        #endregion Methods
    }
}