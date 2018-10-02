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
            Login("admin", "secret");
            GoToGroupsPage();
            CreateNewGroup();
            FillGroupForm("group_name", "group_header", "group_footer");
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

        private void FillGroupForm(string groupName, string groupHeader, string groupFooter)
        {
            _driver.FindElement(By.Name("group_name")).SendKeys(groupName);
            _driver.FindElement(By.Name("group_header")).SendKeys(groupHeader);
            _driver.FindElement(By.Name("group_footer")).SendKeys(groupFooter);
        }

        private void CreateNewGroup()
        {
            _driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupsPage()
        {
            _driver.FindElement(By.CssSelector("a[href *= group]")).Click();
        }

        private void Login(string username, string password)
        {
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys(username);
            _driver.FindElement(By.CssSelector("input[type = password]")).SendKeys(password);
            _driver.FindElement(By.CssSelector("input[type = submit][value = Login]")).Click();
        }

        private void OpenHomePage()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "/addressbook");
        }
    }
}