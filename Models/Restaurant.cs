using System.ComponentModel.DataAnnotations;

namespace BujairiTic.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Type { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        // الحد الأدنى للحجز
        public decimal MinimumCharge { get; set; }

        // صورة الغلاف
        [MaxLength(500)]
        public string ImageUrl { get; set; }

        // لوجو المطعم
        [MaxLength(500)]
        public string LogoUrl { get; set; }
    }
}
