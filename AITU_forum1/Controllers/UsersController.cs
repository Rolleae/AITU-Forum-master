using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AITU_forum1.Dtos;
using AITU_forum1.Models;
using AITU_forum1.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AITU_forum1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UsersController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [Authorize(Roles = "LeaderOfGroup")] 
        [HttpGet]
        public ActionResult<ICollection<UserDto>> GetUsers()
        {
            IEnumerable<User> innerStudents = _userRepo.GetUsers();
            ICollection<UserDto> users = new LinkedList<UserDto>();

            foreach (User s in innerStudents)
            {
                users.Add(new UserDto()
                {
                    Name = s.Name,
                    Surname = s.Surname,
                    Birthday = s.Birthday,
                    GroupId = s.GroupId
                });
            }
            return Ok(users);
        }
        [Authorize(Roles = "LeaderOfGroup")]
        [HttpGet("{id}")]
        public ActionResult GetUserById(Guid id)
        {
            if (_userRepo.GetUserbyId(id) != null)
            {
                return Ok(_userRepo.GetUserbyId(id));
            }
            return BadRequest("No post was found!");
        }
        [HttpPost("update")]
        public ActionResult UpdatePost(User user)
        {
            if (_userRepo.UpdateUser(user))
            {
                return Ok("User has been updated");
            }
            return BadRequest("Problem with updating the user");
        }

        [HttpPost]
        public ActionResult AddUser(UserDto user)
        {
            User us = new User(user);

            if(_userRepo.AddUser(us))
            {
                return Ok("A new user has been created");
            }
            return BadRequest("Some problem occured");
        }
        [Authorize(Roles = "LeaderOfGroup")]
        [HttpPost("delete")]
        public ActionResult DeleteUser(Guid id)
        {
            if (_userRepo.DeleteUser(id))
            {
                return Ok("User was deleted");
            }
            return BadRequest("Some problem occured during deletion of the user");
        }
    }
}
