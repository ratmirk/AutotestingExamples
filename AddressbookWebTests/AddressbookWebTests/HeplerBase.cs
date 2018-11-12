using OpenQA.Selenium;
namespace AddressbookWebTests
{
    public class HeplerBase
    {
        protected IWebDriver Driver;

        public HeplerBase(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}