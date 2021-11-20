using DiscountStore.Areas.Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscountStore.Areas.Cart.Services
{
    public class CartService : ICartService
    {
        public StoreCart currentCart => _cart;
        private StoreCart _cart = new StoreCart();
        public void Add(Item item)
        {
            throw new NotImplementedException();
           // _cart.Items.Add(item);
        }

        public void Remove(Item item)
        {
            throw new NotImplementedException();
            //_cart.Items.Remove(item);
        }

        public double GetTotal()
        {
            throw new NotImplementedException();
            //double total = 0;
            //List<string> skus = _cart.Items.Select(x=> x.SKU).Distinct().ToList();
            //foreach (var sku in skus)
            //{
            //    var item = _cart.Items.FirstOrDefault(x=>x.SKU == sku);
            //    var quantity = _cart.Items.Count(x => x.SKU == item.SKU);
            //    var price = quantity / item.Discount.Quantity * item.Discount.Price + quantity % item.Discount.Quantity * item.Price;
            //    total += price;
            //}
            //return total;
        }
    }
}
