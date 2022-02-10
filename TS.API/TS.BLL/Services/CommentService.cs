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
    public class CommentService : ICommentService
    {
        private IGenericRepository<Ticket> _ticketRepository = null;
        private IGenericRepository<Comment> _commentRepository = null;

        public CommentService(IGenericRepository<Ticket> ticketRepository, IGenericRepository<Comment> commentRepository)
        {
            _ticketRepository = ticketRepository;
            _commentRepository = commentRepository;
        }

        public Comment Create(Ticket ticket, User creator, string content)
        {
            if (creator.ID == ticket.User.ID)
                creator = ticket.User;

            Comment comment = new Comment();

            comment.Content = content;
            comment.Creator = creator;
            comment.Ticket = ticket;

            ticket.Comments.Add(comment);

            _ticketRepository.Update(ticket);
            _ticketRepository.Save();

            return comment;
        }

        public Comment GetById(int id)
        {
            return _commentRepository.GetById(id);
        }

        public bool Delete(int id)
        {
            var comment = GetById(id);

            if (comment == null)
                return false;

            _commentRepository.Delete(comment);
            _commentRepository.Save();

            return true;
        }
    }
}
