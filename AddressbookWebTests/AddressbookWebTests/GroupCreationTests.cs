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
            OpenHomePage();
            Login();
            GoToGroupsPage();
            CreateNewGroup();
            FillGroupForm();
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }

        private void ReturnToGroupsPage()
        {
            _driver.FindElement(By.CssSelector("div[class = msgbox] > i > a[href *= group]")).Click();
        }

        private void SubmitGroupCreation()
        {
            _driver.FindElement(By.CssSelector("input[type = submit][name = submit]")).Click();
        }

        private void FillGroupForm()
        {
            _driver.FindElement(By.Name("group_name")).SendKeys("group_name");
            _driver.FindElement(By.Name("group_header")).SendKeys("group_header");
            _driver.FindElement(By.Name("group_footer")).SendKeys("group_footer");
        }

        private void CreateNewGroup()
        {
            _driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupsPage()
        {
            _driver.FindElement(By.CssSelector("a[href *= group]")).Click();
        }

        private void Login()
        {
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys("admin");
        }

        private void OpenHomePage()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "/addressbook");
        }
    }
}