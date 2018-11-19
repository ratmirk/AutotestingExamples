using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            Application.Navigator.GoToHomePage();
            Application.LoginHelper.Login(new AccountData("admin", "secret"));
            Application.Navigator.GoToEditContactPage();
            var contact = new ContactData
            {
                FirstName = "Foo",
                MiddleName = "Bar",
                LastName = "Spam",
                NickName = "Eggs"
            };
            Application.ContactHelper.FillContactForm(contact);
            Application.ContactHelper.SubmitContactCreation();
        }
    }
}