using System.Collections.Generic;

namespace AddressbookWebTests
{
    public class GroupsTestBase : AuthTestBase
    {
        protected List<GroupData> GroupList;

        protected static List<GroupData> RandomGroupDataProvider()
        {
            var groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(Randomizer.GenerateRandomString(30), Randomizer.GenerateRandomString(100), Randomizer.GenerateRandomString(100)));
            }
            return groups;
        }
    }
}
