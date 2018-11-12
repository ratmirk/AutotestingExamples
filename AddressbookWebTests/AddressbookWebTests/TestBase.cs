using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressbookWebTests
{
    public class TestBase
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

        protected void OpenHomePage()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "/addressbook");
        }

        protected void Login(AccountData account)
        {
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys(account.Username);
            _driver.FindElement(By.CssSelector("input[type = password]")).SendKeys(account.Password);
            _driver.FindElement(By.CssSelector("input[type = submit][value = Login]")).Click();
        }

        protected void GoToGroupsPage()
        {
            _driver.FindElement(By.CssSelector("a[href *= group]")).Click();
        }

        protected void GoToEditContactPage()
        {
            _driver.FindElement(By.CssSelector("a[href *= edit]")).Click();
        }

        protected void CreateNewGroup()
        {
            _driver.FindElement(By.Name("new")).Click();
        }

        protected void FillGroupForm(GroupData group)
        {
            _driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            _driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            _driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        protected void FillContactForm(ContactData contact)
        {
            _driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            _driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);
            _driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            _driver.FindElement(By.Name("nickname")).SendKeys(contact.NickName);
        }

        protected void SubmitGroupCreation()
        {
            _driver.FindElement(By.CssSelector("input[type = submit][name = submit]")).Click();
        }

        protected void SubmitContactCreation()
        {
            _driver.FindElement(By.CssSelector("input[type = submit][name = submit]")).Click();
        }

        protected void ReturnToGroupsPage()
        {
            _driver.FindElement(By.CssSelector("div[class = msgbox] > i > a[href *= group]")).Click();
        }
    }
}
