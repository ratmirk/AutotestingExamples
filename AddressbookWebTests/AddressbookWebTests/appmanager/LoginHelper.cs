using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            Type(By.Name("user"), account.Username);
            Type(By.CssSelector("input[type = password]"), account.Password);
            Driver.FindElement(By.CssSelector("input[type = submit][value = Login]")).Click();
        }
    }
}