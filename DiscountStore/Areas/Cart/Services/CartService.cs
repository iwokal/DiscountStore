﻿using DiscountStore.Areas.Cart.Models;
using System;
using System.Collections.Generic;

namespace DiscountStore.Areas.Cart.Services
{
    public class CartService : ICartService
    {
        public StoreCart currentCart => _cart;
        private StoreCart _cart => _cart ?? new StoreCart();
        public void Add(Item item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Item item)
        {
            throw new NotImplementedException();
        }

        public double GetTotal()
        {
            throw new NotImplementedException();
        }
    }
}
