using System.Collections.Generic;

namespace DiscountStore.Areas.Cart.Models
{
    public class StoreCart
    {
        public StoreCart()
        {
            Items = new Dictionary<string, Item>();
        }

        public Dictionary<string, Item> Items { get; set; }
    }
}