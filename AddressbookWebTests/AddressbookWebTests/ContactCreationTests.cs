using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactCreationTests
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
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToEditContactPage();
            var contact = new ContactData
            {
                FirstName = "Foo",
                MiddleName = "Bar",
                LastName = "Spam",
                NickName = "Eggs"
            };
            FillContactForm(contact);
            SubmitContactCreation();
  }

        private void SubmitContactCreation()
        {
            _driver.FindElement(By.CssSelector("input[type = submit][name = submit]")).Click();
        }

        private void FillContactForm(ContactData contact)
        {
            _driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            _driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);
            _driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            _driver.FindElement(By.Name("nickname")).SendKeys(contact.NickName);
        }

        private void GoToEditContactPage()
        {
            _driver.FindElement(By.CssSelector("a[href *= edit]")).Click();
        }

        private void Login(AccountData account)
        {
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys(account.Username);
            _driver.FindElement(By.CssSelector("input[type = password]")).SendKeys(account.Password);
            _driver.FindElement(By.CssSelector("input[type = submit][value = Login]")).Click();
        }

        private void OpenHomePage()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "/addressbook");
        }
    }
}