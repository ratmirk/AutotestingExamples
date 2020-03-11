using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class HelperBase
    {
        protected readonly IWebDriver Driver;
        protected readonly ApplicationManager Manager;

        protected HelperBase(ApplicationManager manager)
        {
            Driver = manager.Driver;
            Manager = manager;
        }

        protected HelperBase AcceptAlert()
        {
            Driver.SwitchTo().Alert().Accept();
            Driver.SwitchTo().DefaultContent();
            return this;
        }

        protected void Type(By locator, string text)
        {
            if (text == null) return;
            Driver.FindElement(locator).Clear();
            Driver.FindElement(locator).SendKeys(text);
        }

        protected bool IsElementPresent(By locator)
        {
            try
            {
                Driver.FindElement(locator);
                return true;
            } catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}