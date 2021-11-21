using DiscountStore.Areas.DataAccess;
using System;
using System.Linq;

namespace DiscountStore.Areas.Cart.Services
{
    public class PriceService : IPriceService
    {
        public double GetPriceBySku(string sku)
        {
            try
            {
                return SqliteDataAccess.LoadPrices().FirstOrDefault(i => i.SKU == sku).Price;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
