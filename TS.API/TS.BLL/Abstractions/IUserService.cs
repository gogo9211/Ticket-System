using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Entities;
using TS.DTO.Responses;

namespace TS.BLL.Abstractions
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);

        User Create(string username, string password);

        bool Delete(int id);

        AuthenticationResponseDTO Login(string username, string password);
    }
}
