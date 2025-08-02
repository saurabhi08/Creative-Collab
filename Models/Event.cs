using System.ComponentModel.DataAnnotations;

namespace MindAndMarket.Models
{
    public class Event
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
        
        [StringLength(100)]
        public string? Location { get; set; }
        
        public int MaxCapacity { get; set; }
        
        public int CurrentAttendees { get; set; }
        
        [StringLength(50)]
        public string? EventType { get; set; } // Storytime, Book Signing, Cooking Demo, etc.
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public ICollection<Book> RelatedBooks { get; set; } = new List<Book>();
    }
} 