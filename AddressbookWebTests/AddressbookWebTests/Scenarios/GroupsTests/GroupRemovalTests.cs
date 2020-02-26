using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupsTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            // Arrange
            GroupList = Application.Groups.GetGroupList();

            // Act
            Application.Groups.Remove(0);

            // Assert
            var newGroups = Application.Groups.GetGroupList();
            newGroups.Select(x => x.Id).Should().NotContain(GroupList[0].Id);
            GroupList.RemoveAt(0);
            GroupList.Should().BeEquivalentTo(newGroups, options => options.Including(x => x.Name));
        }
    }
}