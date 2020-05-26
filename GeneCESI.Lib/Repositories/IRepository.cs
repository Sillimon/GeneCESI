using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneCESI.Lib.Repositories
{
    public interface IRepository<T> where T : class
    {
        IDbConnection _connection { get; set; }
        void Insert(T entity);
        void Delete(T entity);
        T GetById(UInt32 id);
        IQueryable<T> GetAll();
    }
}
