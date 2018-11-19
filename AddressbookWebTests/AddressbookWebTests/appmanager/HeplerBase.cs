using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class HeplerBase
    {
        protected readonly IWebDriver Driver;
        protected readonly ApplicationManager Manager;

        protected HeplerBase(ApplicationManager manager)
        {
            Driver = manager.Driver;
            Manager = manager;
        }
    }
}