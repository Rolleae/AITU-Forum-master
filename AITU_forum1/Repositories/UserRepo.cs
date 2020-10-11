using AITU_forum1.Data;
using AITU_forum1.Models;
using AITU_forum1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AITU_forum1.Repositories
{
    public class UserRepo : IUserRepo
    {
        private DataContext _context;

        public UserRepo(DataContext context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            _context.UserList.Add(user);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteUser(Guid id)
        {
            var user = _context.UserList.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _context.UserList.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public User GetUserbyId(Guid id)
        {
            return _context.UserList.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<User> GetUsers()
        {
            return _context.UserList.Include(x => x.Group).OrderBy(x => x.Name);
        }

        public bool UpdateUser(User user)
        {
            return true;
        }
    }
}
