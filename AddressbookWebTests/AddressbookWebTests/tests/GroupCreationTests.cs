using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            Application.Navigator.GoToHomePage();
            Application.LoginHelper.Login(new AccountData("admin", "secret"));
            Application.Navigator.GoToGroupsPage();
            Application.GroupHelper.CreateNewGroup();
            Application.GroupHelper.FillGroupForm(new GroupData("group_name", "group_header", "group_footer"));
            Application.GroupHelper.SubmitGroupCreation();
            Application.GroupHelper.ReturnToGroupsPage();
        }
    }
}