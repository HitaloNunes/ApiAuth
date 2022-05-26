using ApiAuth.Model;
using System.Collections.Generic;
using System.Linq;

namespace ApiAuth.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User> {
                new () { Id = 1, UserName = "batman", Password = "batman", Role = "manager" },
                new () { Id = 1, UserName = "robin", Password = "robin", Role = "employee" }
            };
            return users
                .FirstOrDefault(x => x.UserName.ToLower() == username && x.Password == password);
        }
    }
}
