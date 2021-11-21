namespace DiscountStore.Areas.Cart.Services
{
    public interface IPriceService
    {
        double GetPriceBySku(string sku);
    }
}
