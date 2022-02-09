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
    public class TicketService : ITicketService
    {
        private IGenericRepository<Ticket> _ticketRepository = null;
        private IGenericRepository<User> _userRepository = null;

        public TicketService(IGenericRepository<Ticket> ticketRepository, IGenericRepository<User> userRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
        }

        public List<Ticket> GetAll()
        {
            return _ticketRepository.GetAll()
               .ToList();
        }

        public Ticket Create(User user, string title, string description)
        {
            Ticket ticket = new Ticket();

            ticket.Title = title;
            ticket.Description = description;
            ticket.User = user;

            user.Tickets.Add(ticket);

            _userRepository.Update(user);
            _userRepository.Save();

            return ticket;
        }

        public Ticket GetById(int id)
        {
            return _ticketRepository.GetById(id);
        }

        public bool Delete(int id)
        {
            if (GetById(id) == null)
                return false;

            _ticketRepository.Delete(id);
            _ticketRepository.Save();

            return true;
        }
    }
}
