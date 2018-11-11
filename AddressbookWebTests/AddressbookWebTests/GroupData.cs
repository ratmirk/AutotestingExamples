namespace AddressbookWebTests
{
    internal class GroupData
    {
        public GroupData(string name, string header = "", string footer = "")
        {
            Name = name;
            Header = header;
            Footer = footer;
        }

        public string Name { get;}
        public string Header { get; }
        public string Footer { get; }
    }
}
