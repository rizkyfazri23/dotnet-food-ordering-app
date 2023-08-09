using System;
using System.Collections.Generic;

namespace warteg.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
