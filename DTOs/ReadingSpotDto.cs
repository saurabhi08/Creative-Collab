namespace MindAndMarket.DTOs
{
    public class ReadingSpotDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public string? Amenities { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateReadingSpotDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string? Amenities { get; set; }
    }

    public class UpdateReadingSpotDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public string? Amenities { get; set; }
    }
} 