using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithInvalidData()
        {
            Application.Auth.Logout();

            var account = new AccountData("admin", "invalid");
            Application.Auth.Login(account);

            Assert.IsFalse(Application.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithValidData()
        {
            Application.Auth.Logout();

            var account = new AccountData("admin", "secret");
            Application.Auth.Login(account);

            Assert.IsTrue(Application.Auth.IsLoggedIn(account));
        }
    }
}