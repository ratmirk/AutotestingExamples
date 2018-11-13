using OpenQA.Selenium;
namespace AddressbookWebTests
{
    public class NavigationHepler : HeplerBase
    {
        private string _baseUrl;

        public NavigationHepler(IWebDriver driver, string baseUrl) : base(driver)
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
