using DiscountStore.Areas.Cart.Models;
using DiscountStore.Areas.DataAccess;
using System.Linq;

namespace DiscountStore.Areas.Cart.Services
{
    public class DiscountService: IDiscountService
    {
        public Discount GetDiscountBySku(string sku)
        {
            var discount = new Discount();
            discount.Quantity = SqliteDataAccess.LoadDiscounts().FirstOrDefault(i => i.SKU == sku).Quantity;
            discount.Price = SqliteDataAccess.LoadDiscounts().FirstOrDefault(i => i.SKU == sku).Price;
            return discount;
        }
    }
}
