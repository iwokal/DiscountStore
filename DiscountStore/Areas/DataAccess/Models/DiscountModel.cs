namespace DiscountStore.Areas.DataAccess.Models
{
    public class DiscountModel
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}