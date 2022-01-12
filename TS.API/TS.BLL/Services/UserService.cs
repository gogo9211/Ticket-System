using Microsoft.IdentityModel.Tokens;
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

        public int Login(string username, string password)
        {
            var users = GetAll();

            foreach (var user in users) {
                if (user.Username == username && user.Password == password) {
                    //return user.ID;
                    var token = GenerateJwtToken(user);

                    return new AuthenticateResponse(user, token); // need to create AuthenticateResponse
                    /*
                    public class AuthenticateResponse
                    {
                        public int Id { get; set; }
                        public string FirstName { get; set; }
                        public string LastName { get; set; }
                        public string Username { get; set; }
                        public string Token { get; set; }


                        public AuthenticateResponse(User user, string token)
                        {
                            Id = user.Id;
                            FirstName = user.FirstName;
                            LastName = user.LastName;
                            Username = user.Username;
                            Token = token;
                        }
                    }*/
                }
            }

            return -1;
        }

        private string GenerateJwtToken(User user) {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret); // error
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }), // error
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
