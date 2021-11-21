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
            service.currentCart.Items = new Dictionary<string, Item>();
            service.Add(item);

            // Assert
            Assert.IsNotNull(service.currentCart.Items);
            Assert.AreEqual(1, service.currentCart.Items.Count);
            Assert.AreEqual(item, service.currentCart.Items["test"]);
        }

        [TestMethod]
        public void AddSameItem()
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

            // Act
            service.currentCart.Items = new Dictionary<string, Item>();
            service.Add(item);
            service.Add(item2);

            // Assert
            Assert.IsNotNull(service.currentCart.Items);
            Assert.AreEqual(1, service.currentCart.Items.Count);
            Assert.AreEqual(2, service.currentCart.Items["test"].Quantity);
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
                SKU = "test2",
                Price = 1,
                Discount = new Discount
                {
                    Price = 2,
                    Quantity = 3
                }
            };

            service.currentCart.Items = new Dictionary<string, Item>() { {item.SKU, item }, { item2.SKU, item2 } };

            // Act 
            service.Remove(item);

            // Assert
            Item outValue;
            Assert.IsNotNull(service.currentCart.Items);
            Assert.AreEqual(1, service.currentCart.Items.Count);
            Assert.IsFalse(service.currentCart.Items.TryGetValue("test", out outValue));
            Assert.IsNull(outValue);
        }

        [TestMethod]
        public void RemoveBySku()
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
                SKU = "test2",
                Price = 1,
                Discount = new Discount
                {
                    Price = 2,
                    Quantity = 3
                }
            };

            service.currentCart.Items = new Dictionary<string, Item>() { { item.SKU, item }, { item2.SKU, item2 } };

            // Act 
            service.Remove(item.SKU);

            // Assert
            Item outValue;
            Assert.IsNotNull(service.currentCart.Items);
            Assert.AreEqual(1, service.currentCart.Items.Count);
            Assert.IsFalse(service.currentCart.Items.TryGetValue("test", out outValue));
            Assert.IsNull(outValue);
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
                SKU = "test2",
                Price = 1,
                Discount = new Discount
                {
                    Price = 2,
                    Quantity = 3
                }
            };

            service.currentCart.Items = new Dictionary<string, Item>() { { item.SKU, item }, { item2.SKU, item2 } };

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
            Item mug = new Item
            {
                SKU = "mug",
                Price = 1,
                Quantity = 2,
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

            service.currentCart.Items = new Dictionary<string, Item>() { { mug.SKU, mug }, { vase.SKU, vase } };

            // Act 
            var total = service.GetTotal();

            // Assert
            Assert.IsNotNull(service.currentCart.Items);
            Assert.AreEqual(2.7, total);
        }

        [TestMethod]
        public void GetTotalWithoutDiscountOnItem()
        {
            // Arrange
            CartService service = new CartService();
            Item item = new Item
            {
                SKU = "test",
                Price = 1
            };

            Item item2 = new Item
            {
                SKU = "test2",
                Price = 3,
            };

            service.currentCart.Items = new Dictionary<string, Item>() { { item.SKU, item }, { item2.SKU, item2 } };

            // Act 
            var total = service.GetTotal();

            // Assert
            Assert.IsNotNull(service.currentCart.Items);
            Assert.AreEqual(4, total);
        }

        [TestMethod]
        public void Clear()
        {
            // Arrange
            CartService service = new CartService();
            Item mug = new Item
            {
                SKU = "mug",
                Price = 1,
                Quantity = 2,
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

            service.currentCart.Items = new Dictionary<string, Item>() { { mug.SKU, mug }, { vase.SKU, vase } };

            // Act 
            service.Clear();

            // Assert
            Assert.IsNotNull(service.currentCart.Items);
            Assert.AreEqual(0, service.currentCart.Items.Count);
        }
    }
}
