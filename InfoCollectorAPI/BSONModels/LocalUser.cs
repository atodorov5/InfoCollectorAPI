namespace InfoCollectorAPI.BSONModels
{
    public class LocalUser
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string AccountType { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public bool Disabled { get; set; }
        public string Domain { get; set; }
        public string InstallDate { get; set; }
        public bool LocalAccount { get; set; }
        public bool Lockout { get; set; }
        public bool PasswordChangeable { get; set; }
        public bool PasswordExpires { get; set; }
        public bool PasswordRequired { get; set; }
        public string Status { get; set; }
    }
}
