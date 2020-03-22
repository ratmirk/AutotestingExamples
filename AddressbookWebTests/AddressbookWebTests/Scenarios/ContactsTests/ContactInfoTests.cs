using FluentAssertions;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactInfoTests : ContactsTestBase
    {
        [Test]
        public void ContactInformationOnFormTest()
        {
            // Arrange
            Application.Contacts.CreateContactIfNotExist();

            // Act
            var dataFromTable = Application.Contacts.GetContactInfoFromTable(0);
            var dataFromForm = Application.Contacts.GetContactInfoFromForm(0);

            // Assert
            dataFromTable.Should()
                .BeEquivalentTo(dataFromForm, options => options
                    .Including(x => x.FirstName)
                    .Including(x => x.LastName)
                    .Including(x => x.Address)
                    .Including(x => x.AllEmails)
                    .Including(x => x.AllPhones));
        }

        [Test]
        public void ContactInformationOnViewTest()
        {
            // Arrange
            Application.Contacts.CreateContactIfNotExist();

            // Act
            var dataFromForm = Application.Contacts.GetContactInfoFromForm(0);
            var dataFromView = Application.Contacts.GetContactInfoFromView(0);

            // Assert
            var infoFromForm = new[]
            {
                dataFromForm.LastName,
                dataFromForm.FirstName,
                dataFromForm.MiddleName,
                dataFromForm.NickName,
                dataFromForm.Address,
                dataFromForm.HomePhone,
                dataFromForm.MobilePhone,
                dataFromForm.WorkPhone,
                dataFromForm.Email,
                dataFromForm.Email2,
                dataFromForm.Email3
            };

            dataFromView.AllInfo.Should().ContainAll(infoFromForm);
        }
    }
}
