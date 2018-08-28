using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLogic.Elements;
using System.IO;
using System.Threading.Tasks;

namespace NLogic.Tests.Elements.Operators
{
    [TestClass]
    public class Parse
    {
        #region Fields

        private string MockDataDirectory;

        #endregion Fields

        #region Methods

        [TestMethod]
        public async Task ParseCleanOperatorByName()
        {
            var operatorPath = Path.Combine(MockDataDirectory, "NOperator_NameOnly_Clean.json");
            var operatorRaw = File.ReadAllText(operatorPath);

            var nOperator = await NOperator.ParseAsync(operatorRaw);

            Assert.IsNotNull(nOperator);
            Assert.IsNotNull(nOperator.Symbols);
            Assert.IsNotNull(nOperator.Name);
            Assert.IsNotNull(nOperator.ValidTypes);
        }

        [TestInitialize]
        public void SetMockDataDirectory()
        {
            var executingDirectoryPath = Directory.GetCurrentDirectory();
            var projectDirectory = Directory.GetParent(executingDirectoryPath).Parent.Parent.FullName;

            MockDataDirectory = Path.Combine(projectDirectory, "Elements", "MockData");
        }

        #endregion Methods
    }
}