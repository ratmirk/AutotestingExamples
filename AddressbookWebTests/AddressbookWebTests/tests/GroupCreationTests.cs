using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            var group = new GroupData("group_name", "group_header", "group_footer");

            Application.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            var group = new GroupData(string.Empty);

            Application.Groups.Create(group);
        }
    }
}