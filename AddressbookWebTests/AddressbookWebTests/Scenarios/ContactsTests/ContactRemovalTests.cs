using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            Application.Contacts.Remove(1);
        }
    }
}