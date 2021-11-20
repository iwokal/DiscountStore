namespace DiscountStore.Areas.Cart.Models
{
    public class Item
    {
        public string SKU { get; set; }
        public double Price { get; set; }
        public Discount Discount { get; set; }
    }
}