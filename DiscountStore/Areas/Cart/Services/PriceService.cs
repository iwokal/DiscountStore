using DiscountStore.Areas.DataAccess;
using log4net;
using System;
using System.Linq;

namespace DiscountStore.Areas.Cart.Services
{
    public class PriceService : IPriceService
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(PriceService));

        public double GetPriceBySku(string sku)
        {
            try
            {
                var priceEntity = SqliteDataAccess.LoadPrices().FirstOrDefault(i => i.SKU == sku);
                if (priceEntity == null)
                {
                    throw new ArgumentException();
                }
                return priceEntity.Price;
            }
            catch(Exception ex)
            {
                _log.Error($"Error while fetching the price from database for item SKU({sku}): ", ex);
                throw ex;
            }
        }
    }
}
