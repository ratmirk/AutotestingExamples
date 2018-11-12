using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        

        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            CreateNewGroup();
            FillGroupForm(new GroupData("group_name", "group_header", "group_footer"));
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }
    }
}