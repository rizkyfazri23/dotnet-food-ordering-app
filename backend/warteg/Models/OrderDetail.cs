namespace warteg.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; } 

    }
}
