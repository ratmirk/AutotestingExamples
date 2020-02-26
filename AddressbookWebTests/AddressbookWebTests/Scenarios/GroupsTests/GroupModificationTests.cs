using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupModificationTests : GroupsTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            // Arrange
            var newGroupData = new GroupData("changed_group_name", "changed_group_header", "changed_group_footer");
            GroupList = Application.Groups.GetGroupList();
            GroupList[0].Name = newGroupData.Name;

            // Act
            Application.Groups.Modify(0, newGroupData);

            // Assert
            var newGroupList = Application.Groups.GetGroupList();
            GroupList.Should()
                .BeEquivalentTo(newGroupList, options => options.Including(x => x.Name));
            newGroupList.Single(x => x.Id == GroupList[0].Id).Name.Should().Be(GroupList[0].Name);
        }

        [Test]
        public void GroupChangeNameTest()
        {
            // Arrange
            var newGroupData = new GroupData("changed_only_group_name", null, null);
            GroupList = Application.Groups.GetGroupList();
            GroupList[0].Name = newGroupData.Name;

            // Act
            Application.Groups.Modify(0, newGroupData);
            var newGroupList = Application.Groups.GetGroupList();
            GroupList.Should()
                .BeEquivalentTo(newGroupList, options => options.Including(x => x.Name));
            newGroupList.Single(x => x.Id == GroupList[0].Id).Name.Should().Be(GroupList[0].Name);
        }
    }
}