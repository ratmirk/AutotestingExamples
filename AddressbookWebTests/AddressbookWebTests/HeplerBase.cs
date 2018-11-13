using OpenQA.Selenium;
namespace AddressbookWebTests
{
    public class HeplerBase
    {
        protected readonly IWebDriver Driver;

        public HeplerBase(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}