using DiscountStore.Areas.Cart.Models;
using log4net;
using System;

namespace DiscountStore.Areas.Cart.Services
{
    public class CartService : ICartService
    {
        public StoreCart currentCart => _cart;
        //here we would fetch the current cart for the user properly using injected user service 
        private static StoreCart _cart = new StoreCart();
        private static readonly ILog _log = LogManager.GetLogger(typeof(CartService));

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
            Remove(item.SKU);
        }

        public void Remove(string sku)
        {
            _cart.Items.Remove(sku);
        }

        public double GetTotal()
        {
            try
            {
                double total = 0;
                foreach (var item in _cart.Items)
                {
                    var quantity = item.Value.Quantity;
                    var discount = item.Value.Discount;
                    double price;
                    if (discount != null)
                    {
                        price = Math.Round(quantity / discount.Quantity * discount.Price + quantity % discount.Quantity * item.Value.Price, 2);
                    }
                    else
                    {
                        price = Math.Round(quantity * item.Value.Price, 2);
                    }
                    total += price;
                }
                return Math.Round(total, 2);
            }
            catch(Exception ex)
            {
                _log.Error("Error while calculating cart total: ", ex);
                throw;
            }

        }

        public void Clear()
        {
            _cart.Items.Clear();
        }
    }
}
