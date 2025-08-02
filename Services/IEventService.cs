using MindAndMarket.DTOs;

namespace MindAndMarket.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllEventsAsync();
        Task<EventDto?> GetEventByIdAsync(int id);
        Task<EventDto> CreateEventAsync(CreateEventDto createEventDto);
        Task<EventDto?> UpdateEventAsync(int id, UpdateEventDto updateEventDto);
        Task<bool> DeleteEventAsync(int id);
    }
} 