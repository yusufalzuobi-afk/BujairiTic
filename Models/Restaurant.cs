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

 
        public decimal MinimumCharge { get; set; }

        
        [MaxLength(500)]
        public string ImageUrl { get; set; }

        
        [MaxLength(500)]
        public string LogoUrl { get; set; }
    }
}
