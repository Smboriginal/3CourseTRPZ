namespace DAL.Entities
{
    class User
    {
        public int UserId { get; set; } //Id in DB
        public string Name { get; set; } //realname
        public string Login { get; set; } // login to sest
        public string Password { get; set; } //pass to syst
        public FASTRole Role { get; set; } //role for user

        public User(int userId, string name, string login, string password, FASTRole role)
        {
            UserId = userId;
            Name = name;
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
