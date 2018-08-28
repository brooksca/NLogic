using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLogic.Definitions;
using NLogic.Conditions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NLogic.Tests.Conditions
{
    [TestClass]
    public class Parse
    {
        #region Fields

        private string MockDataDirectory;

        #endregion Fields

        #region Methods

        [TestMethod]
        public async Task ParseCleanCondition()
        {
            var conditionPath = Path.Combine(MockDataDirectory, "NCondition_Clean.json");
            var conditionRaw = File.ReadAllText(conditionPath);

            var condition = await NCondition.ParseAsync(conditionRaw);

            Assert.IsNotNull(condition);
            Assert.IsNotNull(condition.Operator);
            Assert.IsNotNull(condition.Reference);
            Assert.IsNotNull(condition.Subject);
        }

        [TestInitialize]
        public void SetMockDataDirectory()
        {
            var executingDirectoryPath = Directory.GetCurrentDirectory();
            var projectDirectory = Directory.GetParent(executingDirectoryPath).Parent.Parent.FullName;

            MockDataDirectory = Path.Combine(projectDirectory, "Conditions", "MockData");
        }

        #endregion Methods
    }
}