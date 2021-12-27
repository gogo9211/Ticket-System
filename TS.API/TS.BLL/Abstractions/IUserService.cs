using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Entities;

namespace TS.BLL.Abstractions
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);

        bool Create(string username, string password);

        bool Delete(int id);
    }
}
