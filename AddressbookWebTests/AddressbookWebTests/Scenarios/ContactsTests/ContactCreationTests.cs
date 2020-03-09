using FluentAssertions;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactCreationTests : ContactsTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            // Arrange
            var contact = new ContactData
            {
                FirstName = "Foo",
                MiddleName = "Bar",
                LastName = "Spam",
                NickName = "Eggs"
            };

            ContactList = Application.Contacts.GetContactList();
            ContactList.Add(contact);

            // Act
            Application.Contacts.Create(contact);

            // Assert
            ContactList.Should()
                .BeEquivalentTo(Application.Contacts.GetContactList(),
                    options => options.Including(c => c.FirstName).Including(c => c.LastName));
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            // Arrange
            var contact = new ContactData
            {
                FirstName = "",
                MiddleName = "",
                LastName = "",
                NickName = ""
            };

            ContactList = Application.Contacts.GetContactList();
            ContactList.Add(contact);

            // Act
            Application.Contacts.Create(contact);

            // Assert
            ContactList.Should()
                .BeEquivalentTo(Application.Contacts.GetContactList(),
                    options => options.Including(c => c.FirstName).Including(c => c.LastName));
        }
    }
}