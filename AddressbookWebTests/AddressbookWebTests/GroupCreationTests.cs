using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests
    {
        private IWebDriver _driver;
        private string _baseUrl;

        [SetUp]
        public void SetUpTests()
        {
            _driver = new ChromeDriver();
            _baseUrl = "http://localhost";
        }

        [TearDown]
        public void TearDownTest() => _driver.Quit();

        [Test]
        public void GroupCreationTest()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "/addressbook");
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys("admin");
            _driver.FindElement(By.CssSelector("input[type = password]")).SendKeys("secret");
            _driver.FindElement(By.CssSelector("input[type = submit][value = Login]")).Click();
        }
    }
}