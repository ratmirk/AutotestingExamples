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
            Driver.FindElement(By.Name("user")).Clear();
            Driver.FindElement(By.Name("user")).SendKeys(account.Username);
            Driver.FindElement(By.CssSelector("input[type = password]")).SendKeys(account.Password);
            Driver.FindElement(By.CssSelector("input[type = submit][value = Login]")).Click();
        }
    }
}
