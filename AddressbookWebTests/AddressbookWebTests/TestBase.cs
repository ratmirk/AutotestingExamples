using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressbookWebTests
{
    public class TestBase
    {
        private IWebDriver _driver;
        private string _baseUrl;
        protected LoginHelper LoginHelper { get; private set; }
        protected NavigationHepler Navigator { get; private set; }
        protected GroupHelper GroupHelper { get; private set; }
        protected ContactHelper ContactHelper { get; private set; }

        [SetUp]
        public void SetUpTests()
        {
            _driver = new ChromeDriver();
            _baseUrl = "http://localhost";

            LoginHelper = new  LoginHelper(_driver);
            Navigator = new NavigationHepler(_driver, _baseUrl);
            GroupHelper = new GroupHelper(_driver);
            ContactHelper = new ContactHelper(_driver);
        }

        [TearDown]
        public void TearDownTest() => _driver.Quit();
    }
}
