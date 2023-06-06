using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.Models;
using MusicStore.Services;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetDiscount_ArticlesPrice10_Returns0()
        {
            //ARRANGE
            List<CartItem> item = new List<CartItem>()
            {
                new CartItem {Count = 1, Album = new Album {Price=10 } },
                new CartItem {Count = 2, Album = new Album {Price=5 } }
            };
            //ACT

            var discount = new DiscountTotalPrice();
            int result = discount.GetDiscount(item);

            //ASSERT
            Assert.AreEqual(0, result);

        }

        [TestMethod]
        public void GetDiscount_ArticlesPrice30_Returns5()
        {
            //ARRANGE
            List<CartItem> item = new List<CartItem>()
            {
                new CartItem {Count = 1, Album = new Album {Price=20 } },
                new CartItem {Count = 2, Album = new Album {Price=5 } }
            };
            //ACT

            var discount = new DiscountTotalPrice();
            int result = discount.GetDiscount(item);

            //ASSERT
            Assert.AreEqual(5, result);

        }

        [TestMethod]
        public void GetDiscount_ArticlesPrice60_Returns10()
        {
            //ARRANGE
            List<CartItem> item = new List<CartItem>()
            {
                new CartItem {Count = 1, Album = new Album {Price=45 } },
                new CartItem {Count = 2, Album = new Album {Price=5 } }
            };
            //ACT

            var discount = new DiscountTotalPrice();
            int result = discount.GetDiscount(item);

            //ASSERT
            Assert.AreEqual(10, result);

        }
    }
}
