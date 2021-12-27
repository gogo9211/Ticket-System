using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Create(string username, string password)
        {
            User user = new User();

            user.Username = username;
            user.Password = password;

            _userRepository.Insert(user);
            _userRepository.Save();

            return true;
        }

        public bool Delete(int id)
        {
            if (GetById(id) == null)
                return false;

            _userRepository.Delete(id);
            _userRepository.Save();

            return true;
        }
    }
}
