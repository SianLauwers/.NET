using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MvcMovieDemo.DAL
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
                                                    IOrderedQueryable<T>> orderBy = null,
                                                    params Expression<Func<T, object>>[] includes);
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
        /*void Save();*/
    }
}

