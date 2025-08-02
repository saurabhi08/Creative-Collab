using System.ComponentModel.DataAnnotations;

namespace MindAndMarket.Models
{
    public class ReadingSpot
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        [StringLength(100)]
        public string? Location { get; set; }
        
        public int Capacity { get; set; }
        
        public bool IsAvailable { get; set; } = true;
        
        [StringLength(200)]
        public string? Amenities { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
} 