using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class NavigationHelper : HelperBase
    {
        private string _baseUrl;

        public NavigationHelper(ApplicationManager manager, string baseUrl) : base(manager)
        {
            _baseUrl = baseUrl;
        }

        public void GoToHomePage()
        {
            Driver.Navigate().GoToUrl(_baseUrl + "/addressbook");
        }

        public void GoToGroupsPage()
        {
            Driver.FindElement(By.CssSelector("a[href *= group]")).Click();
        }

        public void GoToEditContactPage()
        {
            Driver.FindElement(By.CssSelector("a[href *= edit]")).Click();
        }
    }
}