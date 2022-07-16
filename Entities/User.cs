namespace BootCamp.Adm.Entities
{
    public class User : EntityBaseId
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string MotherLastname { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        public UserStatus userStatus { get; set; }

    }
}
