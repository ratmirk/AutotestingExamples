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
            Application.Navigator.GoToHomePage();
            Application.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest() => Application.Stop();
    }
}