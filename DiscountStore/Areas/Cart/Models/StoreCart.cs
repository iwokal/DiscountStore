using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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