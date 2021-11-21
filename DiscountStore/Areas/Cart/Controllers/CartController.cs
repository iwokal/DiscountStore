using DiscountStore.Areas.Cart.Factories;
using DiscountStore.Areas.Cart.Services;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace DiscountStore.Areas.Cart.Controllers
{
    public class CartController : ApiController
    {
        private ICartService _cartService;
        private DiscountItemFactory _itemFactory;

        public CartController(ICartService cartService, DiscountItemFactory itemFactory)
        {
            _cartService = cartService;
            _itemFactory = itemFactory;
        }

        // POST: Cart/Add/string
        public ActionResult Add(string sku)
        {
            try
            {
                var item = _itemFactory.CreateItem(sku);
                _cartService.Add(item);
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Item added to cart");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Error while fetching item from database");
            }
        }

        // POST: Cart/Remove/string
        public ActionResult Remove(string sku)
        {
            try
            {
                _cartService.Remove(sku);
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Item removed from cart");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Error while removing item from cart");
            }
        }

        // GET: Cart/GetTotal
        public double GetTotal()
        {
           return _cartService.GetTotal();
        }

        // POST: Cart/Clear
        public ActionResult Clear()
        {
            try
            {
                _cartService.Clear();
                return new HttpStatusCodeResult(HttpStatusCode.OK, "All items removed from cart");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Error while clearing the cart");
            }
        }
    }
}