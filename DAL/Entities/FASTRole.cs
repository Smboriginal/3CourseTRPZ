using DAL.Enums;

namespace DAL.Entities
{
    /// <summary>
    /// FAST - приложение для сотрудников
    /// </summary>
    public class FASTRole
    {
        public int FASTRoleId { get; set; } // айди роли юзера
        public string Name { get; set; } // название

        public RoleType Role { get; set; }  // тип роли - дерик, оператор, водила

        public FASTRole(int roleId, string name, RoleType role)
        {
            FASTRoleId = roleId;
            Name = name;
            Role = role;
        }
    }
}