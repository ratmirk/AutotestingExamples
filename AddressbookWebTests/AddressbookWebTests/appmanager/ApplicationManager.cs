using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressbookWebTests

{
    public class ApplicationManager
    {
        private readonly string _baseUrl;
        public IWebDriver Driver { get; }

        public LoginHelper Auth { get; }
        public NavigationHepler Navigator { get; }
        public GroupHelper Groups { get; }
        public ContactHelper Contacts { get; }

        

        public ApplicationManager()
        {
            Driver = new ChromeDriver();
            _baseUrl = "http://localhost";

            Auth = new LoginHelper(this);
            Navigator = new NavigationHepler(this, _baseUrl);
            Groups = new GroupHelper(this);
            Contacts = new ContactHelper(this);
        }

        public void Stop() => Driver.Quit();
    }
}