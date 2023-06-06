using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Models;

namespace MyShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private IRepository<Order> _orderRepository;
        private IRepository<Product> _productRepository;

        public OrderController(IRepository<Order> orderRepo, IRepository<Product> productRepo)
        {
            _orderRepository = orderRepo as GenericRepository<Order>;
            _productRepository= productRepo as GenericRepository<Product>;
        }

        public IActionResult Index()
        {

            var orders = _orderRepository.All();

            return View(orders);
        }


        public IActionResult Create(int id)
        {
            var product = _productRepository.All();
                /*_context.Products.ToList();*/
            
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            var customer = new Customer
            {
                Name = model.Customer.Name,
                ShippingAddress = model.Customer.ShippingAddress,
                City = model.Customer.City,
                PostalCode = model.Customer.PostalCode,
                Country = model.Customer.Country
            };

            var order = new Order
            {
                Orderlines = model.LineItems
                    .Select(line => new Orderline { ProductID = line.ProductID, Quantity = line.Quantity })
                    .ToList(),
                OrderDate = DateTime.Now,
                Customer = customer
            };

            _orderRepository.Insert(order);
            _orderRepository.Save();

            return Ok("Order Created");
        }

    }
}
