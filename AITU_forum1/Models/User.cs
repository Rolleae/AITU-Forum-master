using AITU_forum1.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AITU_forum1.Models
{
    public class User
    {
        public User()
        {

        }

        public User(UserDto user)
        {
            Id = Guid.NewGuid();
            Name = user.Name;
            Surname = user.Surname;
            Birthday = user.Birthday;
            GroupId = user.GroupId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthday { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }

    }
}
