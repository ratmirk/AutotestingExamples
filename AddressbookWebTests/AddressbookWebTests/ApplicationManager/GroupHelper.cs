using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

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

        public GroupHelper Modify(int p, GroupData groupData)
        {
            Manager.Navigator.GoToGroupsPage();
            CreateGroupIfNotExist();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(groupData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int p)
        {
            Manager.Navigator.GoToGroupsPage();
            CreateGroupIfNotExist();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper CreateGroupIfNotExist()
        {
            if (IsGroupExist())
            {
                return this;
            }

            Create(new GroupData());
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
            Driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{p + 1}]")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
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

        public GroupHelper InitGroupModification()
        {
            Driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            Manager.Navigator.GoToGroupsPage();
            var groups = Driver.FindElements(By.CssSelector("span.group"))
                .Select(x => new GroupData(x.Text){Id = x.FindElement(By.TagName("input")).GetAttribute("value")})
                .ToList();

            return groups;
        }

        public bool IsGroupExist()
        {
            return IsElementPresent(By.ClassName("group"));
        }
    }
}