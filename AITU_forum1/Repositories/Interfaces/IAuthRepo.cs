using AITU_forum1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AITU_forum1.Repositories.Interfaces
{
    public interface IAuthRepo
    {
        User Register(User user, string password);
        User Login(string username, string password);
        bool UserExists(string username);
    }
}
