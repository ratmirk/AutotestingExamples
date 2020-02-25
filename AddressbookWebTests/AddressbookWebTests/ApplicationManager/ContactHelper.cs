using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public ContactHelper Create(ContactData contact)
        {
            Manager.Navigator.GoToHomePage();
            Manager.Navigator.GoToAddNewContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            Manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Modify(ContactData newContactData)
        {
            Manager.Navigator.GoToHomePage();
            CreateContactIfNotExist();
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
            Manager.Navigator.GoToHomePage();
            CreateContactIfNotExist();
            SelectContact(p);
            RemoveContact();
            AcceptAlert();
            Manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper CreateContactIfNotExist()
        {
            if (IsContactExist())
            {
                return this;
            }

            Create(new ContactData());
            Manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.NickName);
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

        public bool IsContactExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
    }
}