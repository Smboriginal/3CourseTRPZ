namespace CCL.Security.Identity
{
    //Director
    public class Admin
        : User
    {
        public Admin(int userId, string name, string surname, int storageId)
            : base(userId, name, surname, storageId, nameof(Admin))
        {

        }
    }
}
