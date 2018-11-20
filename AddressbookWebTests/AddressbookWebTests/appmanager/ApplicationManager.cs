using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AddressbookWebTests

{
    public class ApplicationManager
    {
        private readonly string _baseUrl;
        public IWebDriver Driver { get; }
        public WebDriverWait Wait { get; }

        public LoginHelper Auth { get; }
        public NavigationHelper Navigator { get; }
        public GroupHelper Groups { get; }
        public ContactHelper Contacts { get; }


        public ApplicationManager()
        {
            Driver = new ChromeDriver();
            _baseUrl = "http://localhost";
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this, _baseUrl);
            Groups = new GroupHelper(this);
            Contacts = new ContactHelper(this);
        }

        public void Stop() => Driver.Quit();
    }
}