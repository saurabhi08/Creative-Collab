using MindAndMarket.DTOs;

namespace MindAndMarket.Services
{
    public interface IAisleService
    {
        Task<IEnumerable<AisleDto>> GetAllAislesAsync();
        Task<AisleDto?> GetAisleByIdAsync(int id);
        Task<AisleDto> CreateAisleAsync(CreateAisleDto createAisleDto);
        Task<AisleDto?> UpdateAisleAsync(int id, UpdateAisleDto updateAisleDto);
        Task<bool> DeleteAisleAsync(int id);
    }
} 