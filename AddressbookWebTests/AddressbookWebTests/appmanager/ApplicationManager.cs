using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressbookWebTests

{
    public class ApplicationManager
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl;

        public LoginHelper LoginHelper { get; }
        public NavigationHepler Navigator { get; }
        public GroupHelper GroupHelper { get; }
        public ContactHelper ContactHelper { get; }


        public ApplicationManager()
        {
            _driver = new ChromeDriver();
            _baseUrl = "http://localhost";
            LoginHelper = new LoginHelper(_driver);
            Navigator = new NavigationHepler(_driver, _baseUrl);
            GroupHelper = new GroupHelper(_driver);
            ContactHelper = new ContactHelper(_driver);
        }

        public void Stop() => _driver.Quit();
    }
}