using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TS.DAL.Abstractions
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(object id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(T obj);

        void Save();
    }
}
