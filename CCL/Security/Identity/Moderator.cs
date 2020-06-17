using System;
using System.Collections.Generic;
using System.Text;
//Operator
namespace CCL.Security.Identity
{
    public class Moderator
        : User
    {
        public Moderator(int userId, string name, string surname, int storageId)
            : base(userId, name, surname, storageId, nameof(Moderator))
        {

        }
    }
}
