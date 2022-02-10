using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Entities;

namespace TS.BLL.Abstractions
{
    public interface ICommentService
    {
        Comment Create(Ticket ticket, User creator, string content);

        Comment GetById(int id);

        bool Delete(int id);
    }
}
