using System.ComponentModel.DataAnnotations;

namespace MindAndMarket.Models
{
    public class Author
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Biography { get; set; }
        
        [StringLength(100)]
        public string? Nationality { get; set; }
        
        public DateTime? BirthDate { get; set; }
        
        // Navigation properties
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
} 