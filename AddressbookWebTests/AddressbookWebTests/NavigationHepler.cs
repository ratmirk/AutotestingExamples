using OpenQA.Selenium;
namespace AddressbookWebTests
{
    public class NavigationHepler
    {
        private IWebDriver _driver;
        private string _baseURL;

        public NavigationHepler(IWebDriver driver, string baseURL)
        {
            _driver = driver;
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
    }
}
