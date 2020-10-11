using AITU_forum1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AITU_forum1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> UserList { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Post> PostList { get; set; }
    }
}
