using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactModificationTests : ContactsTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            // Arrange
            var newContactData = new ContactData
            {
                FirstName = "newName",
                LastName = "newSurname",
            };

            ContactList = Application.Contacts.GetContactList();
            if (!ContactList.Any()) ContactList.Add(new ContactData());
            ContactList[0].FirstName = newContactData.FirstName;
            ContactList[0].LastName = newContactData.LastName;

            // Act
            Application.Contacts.Modify(0, newContactData);

            // Assert
            var newContactList = Application.Contacts.GetContactList();
            ContactList.Should()
                .BeEquivalentTo(newContactList,
                    options => options.Including(x => x.FirstName).Including(x => x.LastName));

            var contact = newContactList.Single(x => x.Id == ContactList[0].Id);
            contact.FirstName.Should().Be(ContactList[0].FirstName);
            contact.LastName.Should().Be(ContactList[0].LastName);
        }
    }
}