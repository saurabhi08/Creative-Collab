namespace MindAndMarket.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Location { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentAttendees { get; set; }
        public string? EventType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateEventDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Location { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentAttendees { get; set; } = 0;
        public string? EventType { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class UpdateEventDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Location { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentAttendees { get; set; }
        public string? EventType { get; set; }
        public bool IsActive { get; set; }
    }
} 