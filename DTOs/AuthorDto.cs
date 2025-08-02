namespace MindAndMarket.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Biography { get; set; }
        public string? Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    public class CreateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Biography { get; set; }
        public string? Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    public class UpdateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Biography { get; set; }
        public string? Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
    }
} 