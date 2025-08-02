using System.ComponentModel.DataAnnotations;

namespace MindAndMarket.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        [StringLength(100)]
        public string? ManagerName { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Book> RelatedBooks { get; set; } = new List<Book>();
    }
} 