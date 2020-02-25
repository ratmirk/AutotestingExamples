using FluentAssertions;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests : GroupsTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            // Arrange
            var group = new GroupData("group_name", "group_header", "group_footer");
            GroupList = Application.Groups.GetGroupList();
            GroupList.Add(group);

            // Act
            Application.Groups.Create(group);

            // Assert using NUnit
            var newGroups = Application.Groups.GetGroupList();
            GroupList.Sort();
            newGroups.Sort();
            Assert.AreEqual(GroupList, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            // Arrange
            var group = new GroupData(string.Empty);
            GroupList = Application.Groups.GetGroupList();
            GroupList.Add(group);

            // Act
            Application.Groups.Create(group);

            // Assert using Fluent Assertions
            GroupList.Should()
                .BeEquivalentTo(Application.Groups.GetGroupList(), options => options.Including(x => x.Name));
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            // Arrange
            var group = new GroupData("g'n");
            GroupList = Application.Groups.GetGroupList();
            GroupList.Add(group);

            // Act
            Application.Groups.Create(group);

            // Assert
            GroupList.Should()
                .BeEquivalentTo(Application.Groups.GetGroupList(), options => options.Including(x => x.Name));
        }
    }
}