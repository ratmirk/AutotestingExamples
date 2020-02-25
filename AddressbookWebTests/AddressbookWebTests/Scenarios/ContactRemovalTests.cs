using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContatctRemovalTest()
        {
            Application.Contacts.Remove(1);
        }
    }
}