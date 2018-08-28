using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLogic.Elements;
using System.IO;
using System.Threading.Tasks;

namespace NLogic.Tests.Elements.Subjects
{
    [TestClass]
    public class Parse
    {
        #region Fields

        private string MockDataDirectory;

        #endregion Fields

        #region Methods

        [TestMethod]
        public async Task ParseCleansubject()
        {
            var subjectPath = Path.Combine(MockDataDirectory, "NSubject_Clean.json");
            var subjectRaw = File.ReadAllText(subjectPath);

            var subject = await NSubject.ParseAsync(subjectRaw);

            Assert.IsNotNull(subject);
            Assert.IsNotNull(subject.Path);
            Assert.IsNotNull(subject.SubjectType);
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