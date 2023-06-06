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
        private IUnitOfWork _uow;

        public OrderController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {

            var orders = _uow.OrderRepository.All();

            return View(orders);
        }


        public IActionResult Create()
        {
            var product = _uow.ProductRepository.All();
            
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            var customer = _uow.CustomerRepository.Find(filter: x => x.Name == model.Customer.Name).FirstOrDefault();

            if (customer == null)
            {
                customer = new Customer
                {
                    Name = model.Customer.Name,
                    ShippingAddress = model.Customer.ShippingAddress,
                    City = model.Customer.City,
                    PostalCode = model.Customer.PostalCode,
                    Country = model.Customer.Country
                };

            }
            else
            {
                customer.ShippingAddress = model.Customer.ShippingAddress;
                customer.City = model.Customer.City;
                customer.PostalCode = model.Customer.PostalCode;
                customer.Country = model.Customer.Country;
            }
            

            var order = new Order
            {
                Orderlines = model.LineItems
                    .Select(line => new Orderline { ProductID = line.ProductID, Quantity = line.Quantity })
                    .ToList(),
                OrderDate = DateTime.Now,
                Customer = customer
            };

            _uow.OrderRepository.Insert(order);
            _uow.Save();

            return Ok("Order Created");
        }

    }
}
