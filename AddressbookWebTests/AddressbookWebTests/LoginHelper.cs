using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class LoginHelper
    {
        private IWebDriver _driver;

        public LoginHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Login(AccountData account)
        {
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys(account.Username);
            _driver.FindElement(By.CssSelector("input[type = password]")).SendKeys(account.Password);
            _driver.FindElement(By.CssSelector("input[type = submit][value = Login]")).Click();
        }
    }
}
