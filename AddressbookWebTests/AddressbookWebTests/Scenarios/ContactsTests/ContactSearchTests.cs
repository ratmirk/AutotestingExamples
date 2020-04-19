using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AddressbookWebTests
{
    class ContactSearchTests: ContactsTestBase
    {
        [Test]
        public void ContactSearchTest()
        {
            // Arrange
            ContactList = Application.Contacts.GetContactList();
            if (ContactList.FirstOrDefault(x => x.FirstName == "Autocreated") == null)
            {
                Application.Contacts.Create(new ContactData());
                ContactList = Application.Contacts.GetContactList();
            }

            // Act
            Application.Contacts.Search("Autocreated");

            // Assert
            Application.Contacts.NumberOfSearchResults.Should().Be(1);
        }

        [Test]
        public void ContactEmptySearchResultsTest()
        {
            // Arrange
            ContactList = Application.Contacts.GetContactList();
            if (ContactList.FirstOrDefault(x => x.FirstName == "Autocreated") == null)
            {
                Application.Contacts.Create(new ContactData());
                ContactList = Application.Contacts.GetContactList();
            }

            // Act
            Application.Contacts.Search("wrong search");

            // Assert
            Application.Contacts.NumberOfSearchResults.Should().Be(0);
        }
    }
}
