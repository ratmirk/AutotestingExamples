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
            Application.Auth.Login(new AccountData("admin", "secret"));
            Application.Navigator.GoToEditContactPage();
            var contact = new ContactData
            {
                FirstName = "Foo",
                MiddleName = "Bar",
                LastName = "Spam",
                NickName = "Eggs"
            };
            Application.Contacts.FillContactForm(contact);
            Application.Contacts.SubmitContactCreation();
        }
    }
}