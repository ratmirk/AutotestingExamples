using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class HeplerBase
    {
        protected readonly IWebDriver Driver;

        protected HeplerBase(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}