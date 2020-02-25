namespace AddressbookWebTests
{
    public class GroupData
    {
        public GroupData(string name, string header = "", string footer = "")
        {
            Name = name;
            Header = header;
            Footer = footer;
        }

        public GroupData()
        {
            Name = "Autocreated";
        }

        public string Name { get; }
        public string Header { get; }
        public string Footer { get; }
    }
}