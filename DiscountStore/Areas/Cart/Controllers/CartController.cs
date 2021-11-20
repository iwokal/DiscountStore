using DiscountStore.Areas.Cart.Services;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace DiscountStore.Areas.Cart.Controllers
{
    public class CartController : ApiController
    {
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // POST: Cart/Add
        public ActionResult Add()
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        // POST: Cart/Remove
        public ActionResult Remove()
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        // GET: Cart/GetTotal
        public string GetTotal()
        {
            _cartService.GetTotal();
            return "value";
        }
    }
}