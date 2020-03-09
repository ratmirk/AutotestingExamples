using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactsTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            // Arrange
            ContactList = Application.Contacts.GetContactList();
            if (!ContactList.Any())
            {
                Application.Contacts.Create(new ContactData());
                ContactList = Application.Contacts.GetContactList();
            }

            // Act
            Application.Contacts.Remove(0);

            // Assert
            var newContacts = Application.Contacts.GetContactList();
            newContacts.Select(x => x.Id).Should().NotContain(ContactList[0].Id);

            ContactList.RemoveAt(0);
            ContactList.Should().BeEquivalentTo(newContacts,
                options => options.Including(x => x.FirstName).Including(x => x.LastName));
        }
    }
}