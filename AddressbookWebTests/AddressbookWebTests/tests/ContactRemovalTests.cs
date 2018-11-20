using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContatctRemovalTest()
        {
            Application.Contacts.Remove(1);
        }
    }
}