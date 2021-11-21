using DiscountStore.Areas.Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscountStore.Areas.Cart.Services
{
    public class CartService : ICartService
    {
        public StoreCart currentCart => _cart;
        //here we would fetch the current cart for the user properly using injected user service 
        private StoreCart _cart = new StoreCart();
        public void Add(Item item)
        {
            if (_cart.Items.ContainsKey(item.SKU))
            {
                _cart.Items[item.SKU].Quantity += item.Quantity;
            }
            else
            {
                _cart.Items.Add(item.SKU, item);
            }
        }

        public void Remove(Item item)
        {
            _cart.Items.Remove(item.SKU);
        }

        public double GetTotal()
        {
            double total = 0;
            foreach (var item in _cart.Items)
            {
                var quantity = item.Value.Quantity;
                var discount = item.Value.Discount;
                var price = quantity / discount.Quantity * discount.Price + quantity % discount.Quantity * item.Value.Price;
                total += price;
            }
            return total;
        }
    }
}
