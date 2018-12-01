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
        private readonly string _baseUrl;


        private ApplicationManager()
        {
            Driver = new ChromeDriver();
            _baseUrl = "http://localhost";
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this, _baseUrl);
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
                var newInsatnce = new ApplicationManager();
                newInsatnce.Navigator.GoToHomePage();
                Application.Value = newInsatnce;
            }

            return Application.Value;
        }
    }
}