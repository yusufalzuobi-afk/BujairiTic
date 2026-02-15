using static BujairiTic.Models.Enums;

namespace BujairiTic.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }


        public ItemType Type { get; set; }

        public int RestaurantId { get; set; }
        public string Title { get; set; } = "";

        public DateTime BookingDate { get; set; }

        public int Guests { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal LineTotal { get; set; }
        public string SelectedTime { get; set; }

    }

}
