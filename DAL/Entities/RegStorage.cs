using System.Collections.Generic;

namespace DAL.Entities
{
    public class RegStorage
    {
        public int StorageId { get; set; } // каждый склад имеет айди
        public string Name { get; set; } // name of storage
        public FASTRole Role { get; set; } // using role
        public List<User> Users { get; set; } //list of users

        public RegStorage(int storageId, string name, FASTRole role, List<User> users)
        {
            StorageId = storageId;
            Name = name;
            Role = role;
            Users = users;
        }
    }
}
