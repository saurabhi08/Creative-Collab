using System.ComponentModel.DataAnnotations;

namespace MindAndMarket.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        public decimal Price { get; set; }
        
        public int StockQuantity { get; set; }
        
        [StringLength(50)]
        public string? SKU { get; set; }
        
        public bool IsOrganic { get; set; }
        
        public bool IsGlutenFree { get; set; }
        
        // Navigation properties
        public int AisleId { get; set; }
        public Aisle Aisle { get; set; } = null!;
        
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        
        // Many-to-many relationships
        public ICollection<Book> RelatedBooks { get; set; } = new List<Book>();
    }
} 