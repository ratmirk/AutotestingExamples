using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class ContactHelper
    {
        private IWebDriver _driver;

        public ContactHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        public void FillContactForm(ContactData contact)
        {
            _driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            _driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);
            _driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            _driver.FindElement(By.Name("nickname")).SendKeys(contact.NickName);
        }

        public void SubmitContactCreation()
        {
            _driver.FindElement(By.CssSelector("input[type = submit][name = submit]")).Click();
        }
    }
}
