using NUnit.Framework;

namespace AddressbookWebTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        [OneTimeSetUp]
        public void InitApplocationManager()
        {
            ApplicationManager application = ApplicationManager.GetInstance();
            application.Navigator.GoToHomePage();
            application.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}