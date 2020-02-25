using System;

namespace AddressbookWebTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
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

        public bool Equals(GroupData other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
        }

        public override int GetHashCode() => Name.GetHashCode();

        public override string ToString() => Name;

        public int CompareTo(GroupData other) => other is null ? 1 : string.Compare(Name, other.Name, StringComparison.Ordinal);

        public string Name { get; }
        public string Header { get; }
        public string Footer { get; }
    }
}