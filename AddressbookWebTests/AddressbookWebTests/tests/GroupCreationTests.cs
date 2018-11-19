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
            Application.Auth.Login(new AccountData("admin", "secret"));
            Application.Navigator.GoToGroupsPage();
            Application.Groups.CreateNewGroup();
            Application.Groups.FillGroupForm(new GroupData("group_name", "group_header", "group_footer"));
            Application.Groups.SubmitGroupCreation();
            Application.Groups.ReturnToGroupsPage();
        }
    }
}