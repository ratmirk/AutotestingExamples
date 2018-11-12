using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class GroupHelper
    {
        private IWebDriver _driver;

        public GroupHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        public void CreateNewGroup()
        {
            _driver.FindElement(By.Name("new")).Click();
        }

        public void FillGroupForm(GroupData group)
        {
            _driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            _driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            _driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        public void SubmitGroupCreation()
        {
            _driver.FindElement(By.CssSelector("input[type = submit][name = submit]")).Click();
        }

        public void ReturnToGroupsPage()
        {
            _driver.FindElement(By.CssSelector("div[class = msgbox] > i > a[href *= group]")).Click();
        }
    }
}
