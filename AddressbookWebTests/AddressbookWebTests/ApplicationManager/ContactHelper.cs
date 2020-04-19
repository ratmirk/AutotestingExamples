using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public ContactHelper Modify(int position, ContactData contactData)
        {
            Manager.Navigator.GoToHomePage();
            CreateContactIfNotExist();
            Edit(position);
            FillContactForm(contactData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Edit(int position)
        {
            Driver.FindElement(By.CssSelector($"tr:nth-child({position + 2}) a[href*='edit'] ")).Click();
            return this;
        }

        public ContactHelper View(int position)
        {
            Driver.FindElement(By.CssSelector($"tr:nth-child({position + 2}) a[href*='view'] ")).Click();
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

        public ContactData GetContactInfoFromTable(int position)
        {
            Manager.Navigator.GoToHomePage();

            var cells = Driver.FindElements(By.Name("entry"))[position].FindElements(By.TagName("td"));
            var lastName = cells[1].Text;
            var firstName = cells[2].Text;
            var address = cells[3].Text;
            var allEmails = cells[4].Text;
            var allPhones = cells[5].Text;

            return new ContactData
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        public ContactData GetContactInfoFromForm(int position)
        {
            Manager.Navigator.GoToHomePage();
            Edit(position);

            var firstName = Driver.FindElement((By.Name("firstname"))).GetAttribute("value");
            var lastName = Driver.FindElement((By.Name("lastname"))).GetAttribute("value");
            var address = Driver.FindElement((By.Name("address"))).GetAttribute("value");

            var homePhone = Driver.FindElement((By.Name("home"))).GetAttribute("value");
            var mobilePhone = Driver.FindElement((By.Name("mobile"))).GetAttribute("value");
            var workPhone = Driver.FindElement((By.Name("work"))).GetAttribute("value");

            var email = Driver.FindElement((By.Name("email"))).GetAttribute("value");
            var email2 = Driver.FindElement((By.Name("email2"))).GetAttribute("value");
            var email3 = Driver.FindElement((By.Name("email3"))).GetAttribute("value");

            return new ContactData
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactData GetContactInfoFromView(int position)
        {
            Manager.Navigator.GoToHomePage();
            View(position);

            var info = Driver.FindElement(By.Id("content")).Text;
            return new ContactData{AllInfo = info};
        }

        public void Search(string term)
        {
            Manager.Navigator.GoToHomePage();
            Driver.FindElement(By.CssSelector("#search-az input")).SendKeys(term);
        }

        public int NumberOfSearchResults
        {
            get
            {
                var text = Driver.FindElement(By.TagName("label")).Text;
                var match = new Regex(@"\d+").Match(text);
                return int.Parse(match.Value);
            }
        }

        private bool IsContactExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
    }
}