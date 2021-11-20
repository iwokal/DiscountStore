using DiscountStore;
using DiscountStore.Areas.Cart.Models;
using DiscountStore.Areas.Cart.Services;
using DiscountStore.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
