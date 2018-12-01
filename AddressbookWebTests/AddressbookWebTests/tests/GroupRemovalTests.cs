using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            Application.Groups.Remove(1);
        }
    }
}