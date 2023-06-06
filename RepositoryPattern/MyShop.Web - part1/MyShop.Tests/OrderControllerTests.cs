using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Controllers;
using MyShop.Web.Models;
using System.Collections.Generic;

namespace MyShop.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void CanCreateOrderWithCorrectModel()
        {

            // // I'm doing something wrong? the mock does not work with my setup either.

            // ARRANGE
            var contextMock = new Mock<ShoppingContext>();

            var productRepositoryMock = new Mock<GenericRepository<Product>>(contextMock.Object);
            var orderRepositoryMock = new Mock<GenericRepository<Order>>(contextMock.Object);

            var order = new CreateOrderModel
            {
                Customer = new CustomerModel { Name = "steven", ShippingAddress = "1", City = "geel", PostalCode = "1234", Country = "belgie" },

                LineItems = new List<LineItemModel> {
                    new LineItemModel { ProductID = 1, Quantity = 3 },
                    new LineItemModel { ProductID = 2, Quantity = 4 } }
            };




            var controller = new OrderController(
                orderRepositoryMock.Object,
                productRepositoryMock.Object

                );
            // ASSERT
            controller.Create(order);
            orderRepositoryMock.Verify(r => r.Insert(It.IsAny<Order>()), Times.AtLeastOnce());


            // ACT

        }
    }
}