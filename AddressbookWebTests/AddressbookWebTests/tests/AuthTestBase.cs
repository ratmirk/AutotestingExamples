using NUnit.Framework;

namespace AddressbookWebTests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetUpApplicationManager()
        {
            Application.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
