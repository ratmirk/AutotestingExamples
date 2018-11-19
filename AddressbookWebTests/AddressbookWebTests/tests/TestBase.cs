using NUnit.Framework;

namespace AddressbookWebTests
{
    public class TestBase
    {
        protected ApplicationManager Application;

        [SetUp]
        public void SetUpTests()
        {
            Application = new ApplicationManager();
        }

        [TearDown]
        public void TeardownTest() => Application.Stop();
    }
}