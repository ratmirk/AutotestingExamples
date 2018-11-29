using NUnit.Framework;

namespace AddressbookWebTests
{
    public class TestBase
    {
        protected ApplicationManager Application { get; private set; }

        [SetUp]
        public void SetUpTests()
        {
            Application = ApplicationManager.GetInstance();
        }
    }
}