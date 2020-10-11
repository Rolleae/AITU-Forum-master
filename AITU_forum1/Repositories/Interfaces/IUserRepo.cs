using AITU_forum1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AITU_forum1.Repositories.Interfaces
{
    public interface IUserRepo
    {
        IQueryable<User> GetUsers();
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(Guid id);
        User GetUserbyId(Guid id);
    }
}
