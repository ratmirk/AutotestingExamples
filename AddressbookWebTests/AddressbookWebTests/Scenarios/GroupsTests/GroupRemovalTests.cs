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
            GroupList.RemoveAt(0);

            // Act
            Application.Groups.Remove(0);

            // Assert
            GroupList.Should().BeEquivalentTo(Application.Groups.GetGroupList(), options => options.Including(x => x.Name));
        }
    }
}