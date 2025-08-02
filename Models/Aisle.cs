using System.ComponentModel.DataAnnotations;

namespace MindAndMarket.Models
{
    public class Aisle
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public int AisleNumber { get; set; }
        
        [StringLength(50)]
        public string? Location { get; set; }
        
        // Navigation properties
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
} 