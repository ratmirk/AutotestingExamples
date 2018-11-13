using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class GroupHelper : HeplerBase
    {
        public GroupHelper(IWebDriver driver) : base(driver)
        {
        }

        public void CreateNewGroup()
        {
            Driver.FindElement(By.Name("new")).Click();
        }

        public void FillGroupForm(GroupData group)
        {
            Driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            Driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            Driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        public void SubmitGroupCreation()
        {
            Driver.FindElement(By.CssSelector("input[type = submit][name = submit]")).Click();
        }

        public void ReturnToGroupsPage()
        {
            Driver.FindElement(By.CssSelector("div[class = msgbox] > i > a[href *= group]")).Click();
        }
    }
}
