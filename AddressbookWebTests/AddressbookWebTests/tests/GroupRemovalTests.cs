using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            Application.Groups.Remove(1);
        }
    }
}