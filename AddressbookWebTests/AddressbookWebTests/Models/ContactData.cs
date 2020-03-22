namespace AddressbookWebTests
{
    public class ContactData
    {
        private string _allPhones;
        private string _allEmails;

        public ContactData()
        {
            FirstName = "Autocreated";
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        public string AllEmails
        {
            get => _allEmails ?? ModifyEmail(Email) + ModifyEmail(Email2) + ModifyEmail(Email3).Trim();
            set => _allEmails = value;
        }

        public string AllPhones
        {
            get => _allPhones ?? (CleanupPhone(HomePhone) + CleanupPhone(MobilePhone) + CleanupPhone(WorkPhone)).Trim();
            set => _allPhones = value;
        }

        public string AllInfo { get; set; }

        private string CleanupPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return string.Empty;

            return phone.Replace(" ", string.Empty)
                       .Replace("-", string.Empty)
                       .Replace("(", string.Empty)
                       .Replace(")", string.Empty) + "\r\n";
        }

        private string ModifyEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return string.Empty;

            return email + "\r\n";
        }
    }
}