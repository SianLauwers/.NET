using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual T Get(int? id)
        {
            return table.Find(id);
        }

        public virtual T Insert(T obj)
        {
            table.Add(obj);
            return obj;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual T Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            return obj;
        }
        
    }
}

