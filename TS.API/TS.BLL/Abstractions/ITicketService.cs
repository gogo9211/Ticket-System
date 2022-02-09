using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Entities;

namespace TS.BLL.Abstractions
{
    public interface ITicketService
    {
        List<Ticket> GetAll();

        Ticket Create(User user, string title, string description);

        Ticket GetById(int id);

        bool Delete(int id);
    }
}
