using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account)) return;

                Logout();
            }

            Type(By.Name("user"), account.Username);
            Type(By.CssSelector("input[type = password]"), account.Password);
            Driver.FindElement(By.CssSelector("input[type = submit][value = Login]")).Click();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                   && Driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                   == $"({account.Username})";
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                Driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
    }
}