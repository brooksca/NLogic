using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLogic.Definitions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NLogic.Tests.Definitions
{
    [TestClass]
    public class Parse
    {
        #region Fields

        private string MockDataDirectory;

        #endregion Fields

        #region Methods

        [TestMethod]
        public async Task ParseCleanDefinition()
        {
            var definitionPath = Path.Combine(MockDataDirectory, "NDefinition_Clean.json");
            var definitionRaw = File.ReadAllText(definitionPath);

            var definition = await NDefinition.ParseAsync(definitionRaw);

            Assert.IsNotNull(definition);
            Assert.IsNotNull(definition.Rulesets);
        }

        [TestInitialize]
        public void SetMockDataDirectory()
        {
            var executingDirectoryPath = Directory.GetCurrentDirectory();
            var projectDirectory = Directory.GetParent(executingDirectoryPath).Parent.Parent.FullName;

            MockDataDirectory = Path.Combine(projectDirectory, "Definitions", "MockData");
        }

        #endregion Methods
    }
}