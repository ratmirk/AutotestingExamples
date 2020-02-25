using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        private List<GroupData> _groupList;

        [Test]
        public void GroupCreationTest()
        {
            // Arrange
            var group = new GroupData("group_name", "group_header", "group_footer");
            _groupList = Application.Groups.GetGroupList();

            // Act
            Application.Groups.Create(group);

            // Assert
            Application.Groups.GetGroupList().Count.Should().Be(_groupList.Count + 1);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            // Arrange
            var group = new GroupData(string.Empty);
            _groupList = Application.Groups.GetGroupList();

            // Act
            Application.Groups.Create(group);

            Application.Groups.GetGroupList().Count.Should().Be(_groupList.Count + 1);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            // Arrange
            var group = new GroupData("g'n");
            _groupList = Application.Groups.GetGroupList();

            // Act
            Application.Groups.Create(group);

            // Assert
            Application.Groups.GetGroupList().Count.Should().Be(_groupList.Count + 1);
        }
    }
}