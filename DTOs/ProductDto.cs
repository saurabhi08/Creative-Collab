namespace MindAndMarket.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? SKU { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsGlutenFree { get; set; }
        public string AisleName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
    }

    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? SKU { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsGlutenFree { get; set; }
        public int AisleId { get; set; }
        public int DepartmentId { get; set; }
    }

    public class UpdateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? SKU { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsGlutenFree { get; set; }
        public int AisleId { get; set; }
        public int DepartmentId { get; set; }
    }
} 