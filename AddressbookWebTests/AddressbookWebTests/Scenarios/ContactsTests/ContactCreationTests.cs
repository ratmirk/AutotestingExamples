using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            var contact = new ContactData
            {
                FirstName = "Foo",
                MiddleName = "Bar",
                LastName = "Spam",
                NickName = "Eggs"
            };


            Application.Contacts.Create(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            var contact = new ContactData
            {
                FirstName = "",
                MiddleName = "",
                LastName = "",
                NickName = ""
            };
            
            Application.Contacts.Create(contact);
        }
    }
}