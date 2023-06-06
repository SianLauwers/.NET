using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        public ShoppingContext _context;
        public DbSet<T> table = null;
        public GenericRepository(ShoppingContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public virtual IEnumerable<T> All()
        {
            return table.ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public virtual T Get(int? id)
        {
            return table.Find(id);
        }

        public virtual T Insert(T obj)
        {
            table.Add(obj);
            return obj;
        }

        /*public void Save()
        {
            _context.SaveChanges();
        }*/

        public virtual T Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            return obj;
        }
        
    }
}

