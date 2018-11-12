using OpenQA.Selenium;
namespace AddressbookWebTests
{
    public class NavigationHepler : HeplerBase
    {
        private string _baseURL;

        public NavigationHepler(IWebDriver driver, string baseURL) : base(driver)
        {
            _baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            _driver.Navigate().GoToUrl(_baseURL + "/addressbook");
        }

        public void GoToGroupsPage()
        {
            _driver.FindElement(By.CssSelector("a[href *= group]")).Click();
        }

        public void GoToEditContactPage()
        {
            _driver.FindElement(By.CssSelector("a[href *= edit]")).Click();
        }
    }
}
