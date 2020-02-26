using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AddressbookWebTests
{
    public class ApplicationManager
    {
        private static readonly ThreadLocal<ApplicationManager> Application = new ThreadLocal<ApplicationManager>();
        private const string BaseUrl = "http://localhost";

        private ApplicationManager()
        {
            var option = new ChromeOptions();
            option.AddExcludedArguments("enable-automation");
            Driver = new ChromeDriver(option);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this, BaseUrl);
            Groups = new GroupHelper(this);
            Contacts = new ContactHelper(this);
        }

        public IWebDriver Driver { get; }
        public WebDriverWait Wait { get; }

        public LoginHelper Auth { get; }
        public NavigationHelper Navigator { get; }
        public GroupHelper Groups { get; }
        public ContactHelper Contacts { get; }

        ~ApplicationManager()
        {
            Driver.Quit();
        }

        public static ApplicationManager GetInstance()
        {
            if (!Application.IsValueCreated)
            {
                var newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                Application.Value = newInstance;
            }

            return Application.Value;
        }
    }
}