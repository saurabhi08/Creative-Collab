namespace MindAndMarket.DTOs
{
    public class AisleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int AisleNumber { get; set; }
        public string? Location { get; set; }
    }

    public class CreateAisleDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int AisleNumber { get; set; }
        public string? Location { get; set; }
    }

    public class UpdateAisleDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int AisleNumber { get; set; }
        public string? Location { get; set; }
    }
} 