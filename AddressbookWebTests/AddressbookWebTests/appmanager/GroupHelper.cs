﻿using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public GroupHelper Create(GroupData group)
        {
            Manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int p, GroupData newGroupData)
        {
            Manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModificattion();
            FillGroupForm(newGroupData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int p)
        {
            Manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            Driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            Driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int p)
        {
            Driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{p}]")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            Driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            Driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            Driver.FindElement(By.CssSelector("input[type = submit][name = submit]")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            Driver.FindElement(By.CssSelector("div[class = msgbox] > i > a[href *= group]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            Driver.FindElement(By.CssSelector("input[type = submit][name = update]")).Click();
            return this;
        }

        public GroupHelper InitGroupModificattion()
        {
            Driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}