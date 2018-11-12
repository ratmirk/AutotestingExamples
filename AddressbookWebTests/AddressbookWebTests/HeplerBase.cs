using OpenQA.Selenium;
namespace AddressbookWebTests
{
    public class HeplerBase
    {
        protected IWebDriver _driver;

        public HeplerBase(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}