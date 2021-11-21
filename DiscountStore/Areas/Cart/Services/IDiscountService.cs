using DiscountStore.Areas.Cart.Models;

namespace DiscountStore.Areas.Cart.Services
{
    public interface IDiscountService
    {
        Discount GetDiscountBySku(string sku);
    }
}
