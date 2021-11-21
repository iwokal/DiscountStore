using DiscountStore.Areas.DataAccess;
using System.Linq;

namespace DiscountStore.Areas.Cart.Services
{
    public class PriceService : IPriceService
    {
        public double GetPriceBySku(string sku)
        {
            return SqliteDataAccess.LoadPrices().FirstOrDefault(i => i.SKU == sku).Price;
        }
    }
}
