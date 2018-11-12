using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            Navigator.GoToHomePage();
            LoginHelper.Login(new AccountData("admin", "secret"));
            Navigator.GoToEditContactPage();
            var contact = new ContactData
            {
                FirstName = "Foo",
                MiddleName = "Bar",
                LastName = "Spam",
                NickName = "Eggs"
            };
            ContactHelper.FillContactForm(contact);
            ContactHelper.SubmitContactCreation();

        }
    }
}