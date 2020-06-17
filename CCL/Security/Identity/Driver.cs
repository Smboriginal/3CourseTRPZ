using System;
using System.Collections.Generic;
using System.Text;
//Driver
namespace CCL.Security.Identity
{
    public class Driver
            : User
    {
        public Driver(int userId, string name, string surname, int storageId)
            : base(userId, name, surname, storageId, nameof(Driver))
        {

        }
    }
}
