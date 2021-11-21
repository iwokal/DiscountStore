using DiscountStore.Areas.Cart.Models;

namespace DiscountStore.Areas.Cart.Factories
{
    public abstract class ItemFactory
    {
        private Item _item = new Item();

        public Item CreatedItem
        {
            get { return _item; }
        }

        public abstract Item CreateItem(string sku);
    }
}