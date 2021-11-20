using DiscountStore;
using DiscountStore.Areas.Cart.Models;
using DiscountStore.Areas.Cart.Services;
using DiscountStore.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DiscountStore.Tests.Controllers
{
    [TestClass]
    public class CartServiceTest
    {
        [TestMethod]
        public void Add()
        {
            // Arrange
            CartService service = new CartService();
            Item item = new Item
            {
                SKU = "test",
                Price = 1,
                Discount = new Discount
                {
                    Price = 2,
                    Quantity = 3
                }
            };

            // Act
            service.Add(item);

            // Assert
            Assert.IsNotNull(service.currentCart.Items);
            Assert.AreEqual(1, service.currentCart.Items.Count);
            Assert.AreEqual(item, service.currentCart.Items[0]);
        }

        [TestMethod]
        public void Remove()
        {
            // Arrange
            CartService service = new CartService();
            Item item = new Item
            {
                SKU = "test",
                Price = 1,
                Discount = new Discount
                {
                    Price = 2,
                    Quantity = 3
                }
            };

            Item item2 = new Item
            {
                SKU = "test",
                Price = 1,
                Discount = new Discount
                {
                    Price = 2,
                    Quantity = 3
                }
            };

            service.currentCart.Items = new List<Item>() { item, item2 };

            // Act 
            service.Remove(item);

            // Assert
            Assert.IsNotNull(service.currentCart.Items);
            Assert.AreEqual(1, service.currentCart.Items.Count);
            Assert.IsFalse(service.currentCart.Items.Contains(item));
        }

        [TestMethod]
        public void GetTotal()
        {
            // Arrange
            CartService service = new CartService();
            Item item = new Item
            {
                SKU = "test",
                Price = 1,
                Discount = new Discount
                {
                    Price = 2,
                    Quantity = 3
                }
            };

            Item item2 = new Item
            {
                SKU = "test",
                Price = 1,
                Discount = new Discount
                {
                    Price = 2,
                    Quantity = 3
                }
            };

            service.currentCart.Items = new List<Item>() { item, item2};

            // Act 
            var total = service.GetTotal();

            // Assert
            Assert.IsNotNull(service.currentCart.Items);
            Assert.AreEqual(2, total);
        }

        [TestMethod]
        public void GetTotalWithDiscount()
        {
            // Arrange
            CartService service = new CartService();
            Item mug1 = new Item
            {
                SKU = "mug",
                Price = 1,
                Discount = new Discount
                {
                    Price = 1.5,
                    Quantity = 2
                }
            };

            Item vase = new Item
            {
                SKU = "vase",
                Price = 1.2,
                Discount = new Discount
                {
                    Price = 2,
                    Quantity = 3
                }
            };

            Item mug2 = new Item
            {
                SKU = "mug",
                Price = 1,
                Discount = new Discount
                {
                    Price = 1.5,
                    Quantity = 2
                }
            };
            service.currentCart.Items = new List<Item>() { mug1, vase, mug2 };

            // Act 
            var total = service.GetTotal();

            // Assert
            Assert.IsNotNull(service.currentCart.Items);
            Assert.AreEqual(2.7, total);
        }
    }
}
