using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        public GenericRepository<Order> OrderRepository { get; }
        public GenericRepository<Customer> CustomerRepository { get; }
        public GenericRepository<Product> ProductRepository { get; }
        
        void Save();
    }
}
