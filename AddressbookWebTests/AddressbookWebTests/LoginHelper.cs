using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class LoginHelper : HeplerBase
    {
        public LoginHelper(IWebDriver driver) : base(driver)
        {
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
