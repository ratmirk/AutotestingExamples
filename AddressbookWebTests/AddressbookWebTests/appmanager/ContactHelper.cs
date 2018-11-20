using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public ContactHelper Create(ContactData contact)
        {
            Manager.Navigator.GoToEditContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            Manager.Navigator.GoToEditContactPage();
            SelectContact(p);
            RemoveContact();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            Driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);
            Driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            Driver.FindElement(By.Name("nickname")).SendKeys(contact.NickName);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            Driver.FindElement(By.CssSelector("input[type = submit][name = submit]")).Click();
            return this;
        }


        public ContactHelper RemoveContact()
        {
            Driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public ContactHelper SelectContact(int p)
        {
            Driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{p}]")).Click();
            return this;
        }
    }
}