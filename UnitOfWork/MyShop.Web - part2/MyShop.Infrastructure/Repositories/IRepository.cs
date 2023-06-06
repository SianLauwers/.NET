using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> All();
        T Get(int? id);
        T Insert(T obj);
        T Update(T obj);
        //void Save();

        IEnumerable<T> Find(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, 
                                                                      IOrderedQueryable<T>> orderBy = null,
                                                                      params Expression<Func<T, object>>[] includes);
    }
}
