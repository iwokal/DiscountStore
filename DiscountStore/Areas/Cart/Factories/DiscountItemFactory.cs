using DiscountStore.Areas.Cart.Models;
using DiscountStore.Areas.Cart.Services;

namespace DiscountStore.Areas.Cart.Factories
{
    public class DiscountItemFactory : ItemFactory
    {
        private IDiscountService _discountService;
        private IPriceService _priceService;

        public DiscountItemFactory(IDiscountService discountService, IPriceService priceService)
        {
            _discountService = discountService;
            _priceService = priceService;
        }

        public override Item CreateItem(string sku)
        {
            CreatedItem.SKU = sku;
            CreatedItem.Price = _priceService.GetPriceBySku(sku);
            CreatedItem.Discount = _discountService.GetDiscountBySku(sku);
            return CreatedItem;
        }
    }
}