using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class HelperBase
    {
        protected readonly IWebDriver Driver;
        protected readonly ApplicationManager Manager;

        protected HelperBase(ApplicationManager manager)
        {
            Driver = manager.Driver;
            Manager = manager;
        }
    }
}