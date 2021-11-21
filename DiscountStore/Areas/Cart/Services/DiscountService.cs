using DiscountStore.Areas.Cart.Models;
using DiscountStore.Areas.DataAccess;
using System.Linq;

namespace DiscountStore.Areas.Cart.Services
{
    public class DiscountService: IDiscountService
    {
        public Discount GetDiscountBySku(string sku)
        {
            var discountFromDB = SqliteDataAccess.LoadDiscounts().FirstOrDefault(i => i.SKU == sku);
            if (discountFromDB != null)
            {
                var discount = new Discount();
                discount.Quantity = discountFromDB.Quantity;
                discount.Price = discountFromDB.Price;
                return discount;
            }
            return null;
        }

        public bool TryGetDiscountBySku(string sku, out Discount discount)
        {
            discount = new Discount();
            var discountFromDB = SqliteDataAccess.LoadDiscounts().FirstOrDefault(i => i.SKU == sku);
            if(discountFromDB != null)
            {
                discount.Quantity = discountFromDB.Quantity;
                discount.Price = discountFromDB.Price;
                return false;
            }
            return true;
        }
    }
}
