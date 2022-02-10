using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Abstractions;

namespace TS.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DatabaseContext _context = null;

        private DbSet<T> table = null;

        public GenericRepository()
        {
            _context = new DatabaseContext(DatabaseContext.ops.dbOptions);
            table = _context.Set<T>();
        }

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(T obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            table.Remove(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
