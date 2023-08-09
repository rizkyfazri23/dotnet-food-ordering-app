using System;
using System.ComponentModel.DataAnnotations;

namespace warteg.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        public Order Order { get; set; }
    }
}
