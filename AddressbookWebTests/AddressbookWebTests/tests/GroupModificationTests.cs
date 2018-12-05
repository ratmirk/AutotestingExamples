using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            var newGroupData = new GroupData("changed_group_name", "changed_group_header", "changed_group_footer");

            Application.Groups.Modify(1, newGroupData);
        }

        [Test]
        public void GroupChangeNameTest()
        {
            var newGroupData = new GroupData("changed_only_group_name", null, null);

            Application.Groups.Modify(1, newGroupData);
        }
    }
}