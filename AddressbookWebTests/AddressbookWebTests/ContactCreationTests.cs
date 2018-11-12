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
            GoToEditContactPage();
            var contact = new ContactData
            {
                FirstName = "Foo",
                MiddleName = "Bar",
                LastName = "Spam",
                NickName = "Eggs"
            };
            FillContactForm(contact);
            SubmitContactCreation();

        }
    }
}