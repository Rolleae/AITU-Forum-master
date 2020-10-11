using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AITU_forum1.Dtos;
using AITU_forum1.Models;
using AITU_forum1.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AITU_forum1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepository;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepo authRepository, IConfiguration config)
        {
            _authRepository = authRepository;
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto userRegisterDTO)
        {
            userRegisterDTO.Username = userRegisterDTO.Username.ToLower();

            if (_authRepository.UserExists(userRegisterDTO.Username))
                return BadRequest("Username already exists!");

            var studentToCreate = new User
            {
                Name = userRegisterDTO.Name,
                Surname = userRegisterDTO.Surname,
                Username = userRegisterDTO.Username,
                Birthday = Convert.ToDateTime(userRegisterDTO.Birthday),
                GroupId = userRegisterDTO.GroupId
            };

            var createdStudent = _authRepository.Register(studentToCreate, userRegisterDTO.Password);
            return StatusCode(201);
        }

        [HttpPost("login")]
            public IActionResult Login(UserLoginDto userLoginDTO)
        {
            var user = _authRepository.Login(userLoginDTO.Username.ToLower(), userLoginDTO.Password);

            if (user == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(3),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}
