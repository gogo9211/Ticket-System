using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.BLL.Abstractions;
using TS.DAL.Abstractions;
using TS.DAL.Entities;
using TS.DAL.DataContext;
using TS.BLL.JWT;

namespace TS.BLL.Services
{
    public class UserService : IUserService
    {
        private IGenericRepository<User> _userRepository = null;
        private AppConfiguration configuration;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;

            configuration = new AppConfiguration();
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

        public bool UserExist(string username)
        {
            var users = GetAll();

            foreach (var user in users)
                if (user.Username == username)
                    return true;

            return false;
        }

        public bool Disable(int id)
        {
            var user = GetById(id);

            if (user == null)
                return false;

            user.Disabled = true;

            _userRepository.Update(user);
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
                    if (user.Disabled)
                        return null;

                    return JWTService.GenerateJwtToken(user, configuration);
                }
            }

            return null;
        }
    }
}
