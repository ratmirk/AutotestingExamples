using NUnit.Framework;

namespace AddressbookWebTests
{
    public class TestBase
    {
        protected ApplicationManager Application;

        [SetUp]
        public void SetUpLogin()
        {
            Application = ApplicationManager.GetInstance();
        }
    }
}
