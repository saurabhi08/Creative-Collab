namespace MindAndMarket.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }

    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
} 