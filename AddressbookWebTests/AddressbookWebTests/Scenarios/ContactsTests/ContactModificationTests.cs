﻿using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            var newContactData = new ContactData
            {
                FirstName = "qwertyu",
                MiddleName = "wer",
                LastName = "we",
                NickName = "wewewe"
            };


            Application.Contacts.Modify(newContactData);
        }
    }
}