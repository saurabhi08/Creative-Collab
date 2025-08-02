using System.ComponentModel.DataAnnotations;

namespace MindAndMarket.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        [StringLength(50)]
        public string? ISBN { get; set; }
        
        public DateTime PublicationDate { get; set; }
        
        public decimal Price { get; set; }
        
        public int StockQuantity { get; set; }
        
        // Navigation properties
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        
        // Many-to-many relationships
        public ICollection<Product> RelatedProducts { get; set; } = new List<Product>();
        public ICollection<Department> RelatedDepartments { get; set; } = new List<Department>();
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
} 