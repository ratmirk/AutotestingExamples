using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class NavigationHelper : HelperBase
    {
        private readonly string _baseUrl;

        public NavigationHelper(ApplicationManager manager, string baseUrl) : base(manager)
        {
            _baseUrl = baseUrl;
        }

        public void GoToHomePage()
        {
            if (Driver.Url == _baseUrl + "/addressbook")
            {
                return;
            }
            Driver.Navigate().GoToUrl(_baseUrl + "/addressbook");
        }

        public void GoToGroupsPage()
        {
            if (Driver.Url == _baseUrl + "/addressbook/group.php" && IsElementPresent(By.Name("submit")))
            {
                return;
            }

            Driver.FindElement(By.CssSelector("a[href *= group]")).Click();
        }

        public void GoToAddNewContactPage()
        {
            if (Driver.Url == _baseUrl + "/addressbook/edit.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }

            Driver.FindElement(By.CssSelector("a[href *= edit]")).Click();
        }
    }
}