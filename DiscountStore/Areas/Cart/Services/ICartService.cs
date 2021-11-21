using DiscountStore.Areas.Cart.Models;

namespace DiscountStore.Areas.Cart.Services
{
    public interface ICartService
    {
        void Add(Item item);
        void Remove(Item item);
        void Remove(string sku);
        double GetTotal();
        void Clear();
    }
}
