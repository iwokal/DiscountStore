using DiscountStore.Areas.Cart.Models;
using DiscountStore.Areas.Cart.Services;
using log4net;
using System;

namespace DiscountStore.Areas.Cart.Factories
{
    public class DiscountItemFactory : ItemFactory
    {
        private IDiscountService _discountService;
        private IPriceService _priceService;
        private static readonly ILog _log = LogManager.GetLogger(typeof(DiscountItemFactory));

        public DiscountItemFactory(IDiscountService discountService, IPriceService priceService)
        {
            _discountService = discountService;
            _priceService = priceService;
        }

        public override Item CreateItem(string sku)
        {
            try
            {
                CreatedItem.SKU = sku;
                CreatedItem.Price = _priceService.GetPriceBySku(sku);
                CreatedItem.Discount = _discountService.GetDiscountBySku(sku);
                return CreatedItem;
            }
            catch (Exception ex)
            {
                _log.Error($"Couldn't create item object for SKU({sku}): ", ex);
                return null;
            }
        }
    }
}