using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(ShoppingContext context) : base(context)
        {
        }

        public override Order Update(Order entity)
        {
            var order = _context.Orders
                .Single(p => p.OrderID == entity.OrderID);

            order.OrderDate = entity.OrderDate;
            order.Orderlines = entity.Orderlines;

            return base.Update(order);

        }
        public override IEnumerable<Order> All()
        {
            var orders = _context.Orders
                .Include(order => order.Orderlines)
                .ThenInclude(orderline => orderline.Product).ToList();

            return orders;

        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = _context.Orders
                .Include(customer => customer.Customer)
                .Include(order => order.Orderlines)
                .ThenInclude(orderline => orderline.Product);

            return await orders.ToListAsync();
        }
    }

}

