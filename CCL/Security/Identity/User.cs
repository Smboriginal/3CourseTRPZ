using System;
using System.Collections.Generic;
using System.Text;
//User
namespace CCL.Security.Identity
{
    public abstract class User
    {
        public int UserId { get; }
        public string Name { get; }
        public string Surname { get; }
        public int RouteId { get; }
        protected string UserType { get; }


        public User(int userId, string name, string surname, int routeId, string userType)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            RouteId = routeId;
            UserType = userType;
        }
    }
}
