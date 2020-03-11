using System.Collections.Generic;
using System.Linq;
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

        public ContactHelper Modify(int position, ContactData newContactData)
        {
            Manager.Navigator.GoToHomePage();
            CreateContactIfNotExist();
            Edit(position);
            FillContactForm(newContactData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Edit(int position)
        {
            Driver.FindElement(By.CssSelector($"tr:nth-child({position + 2}) a[href*='edit'] ")).Click();
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
            Driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{p + 1}]")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            Manager.Navigator.GoToHomePage();
            var contacts = Driver.FindElements(By.CssSelector("tr[name='entry']"))
                .Select(contact => new ContactData
                {
                    LastName = contact.FindElement(By.CssSelector("td:nth-child(2)")).Text,
                    FirstName = contact.FindElement(By.CssSelector("td:nth-child(3)")).Text,
                    Id = contact.FindElement(By.TagName("input")).GetAttribute("value")
                })
                .ToList();

            return contacts;
        }

        private bool IsContactExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
    }
}