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
        public ContactHelper Modify(ContactData newContactData)
        {
            Edit();
            FillContactForm(newContactData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Edit()
        {
            Driver.FindElement(By.CssSelector("td[class='center'] a[href*='edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            Driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            SelectContact(p);
            RemoveContact();
            AcceptAlert();
            Manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Driver.FindElement(By.Name("firstname")).Clear();
            Driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            Driver.FindElement(By.Name("middlename")).Clear(); 
            Driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);
            Driver.FindElement(By.Name("lastname")).Clear();
            Driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            Driver.FindElement(By.Name("nickname")).Clear();
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
            Driver.FindElement(By.CssSelector("input[type = button][onclick = 'DeleteSel()']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int p)
        {
            Driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{p}]")).Click();
            return this;
        }


    }
}