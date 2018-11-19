using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class ContactHelper : HeplerBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public void FillContactForm(ContactData contact)
        {
            Driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            Driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);
            Driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            Driver.FindElement(By.Name("nickname")).SendKeys(contact.NickName);
        }

        public void SubmitContactCreation()
        {
            Driver.FindElement(By.CssSelector("input[type = submit][name = submit]")).Click();
        }
    }
}