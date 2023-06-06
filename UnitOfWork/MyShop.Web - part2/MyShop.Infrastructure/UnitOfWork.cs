using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShoppingContext _context;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Product> productRepository;
        public UnitOfWork(ShoppingContext context)
        {
            _context = context;
        }
        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(_context);
                }
                return orderRepository;
            }
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new CustomerRepository(_context);
                }
                return customerRepository;
            }
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(_context);
                }
                return productRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
