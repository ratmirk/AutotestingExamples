using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressbookWebTests

{
    public class ApplicationManager
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl;

        public LoginHelper Auth { get; }
        public NavigationHepler Navigator { get; }
        public GroupHelper Groups { get; }
        public ContactHelper Contacts { get; }


        public ApplicationManager()
        {
            _driver = new ChromeDriver();
            _baseUrl = "http://localhost";
            Auth = new LoginHelper(_driver);
            Navigator = new NavigationHepler(_driver, _baseUrl);
            Groups = new GroupHelper(_driver);
            Contacts = new ContactHelper(_driver);
        }

        public void Stop() => _driver.Quit();
    }
}