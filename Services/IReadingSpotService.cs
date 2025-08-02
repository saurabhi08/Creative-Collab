using MindAndMarket.DTOs;

namespace MindAndMarket.Services
{
    public interface IReadingSpotService
    {
        Task<IEnumerable<ReadingSpotDto>> GetAllReadingSpotsAsync();
        Task<ReadingSpotDto?> GetReadingSpotByIdAsync(int id);
        Task<ReadingSpotDto> CreateReadingSpotAsync(CreateReadingSpotDto createReadingSpotDto);
        Task<ReadingSpotDto?> UpdateReadingSpotAsync(int id, UpdateReadingSpotDto updateReadingSpotDto);
        Task<bool> DeleteReadingSpotAsync(int id);
    }
} 