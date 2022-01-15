using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TS.BLL.Abstractions;
using TS.DAL.Abstractions;
using TS.DAL.Entities;

namespace TS.BLL.Services
{
    public class UserService : IUserService
    {
        private IGenericRepository<User> _userRepository = null;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll()
                .ToList();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User Create(string username, string password)
        {
            User user = new User();

            user.Username = username;
            user.Password = password;

            _userRepository.Insert(user);
            _userRepository.Save();

            return user;
        }

        public bool Delete(int id)
        {
            if (GetById(id) == null)
                return false;

            _userRepository.Delete(id);
            _userRepository.Save();

            return true;
        }

        public string Login(string username, string password)
        {
            var users = GetAll();

            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return GenerateJwtToken(user);
                }
            }

            return null;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("0UDQ2IvtaZIwJr76Tx4dKORCrHjPMDU81oLLydqADwjm1s9Hsr");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.ID.ToString()) }),

                Expires = DateTime.UtcNow.AddDays(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
