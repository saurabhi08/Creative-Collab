using Microsoft.EntityFrameworkCore;
using MindAndMarket.Data;
using MindAndMarket.DTOs;
using MindAndMarket.Models;

namespace MindAndMarket.Services
{
    public class AisleService : IAisleService
    {
        private readonly MindAndMarketContext _context;

        public AisleService(MindAndMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AisleDto>> GetAllAislesAsync()
        {
            return await _context.Aisles
                .Select(a => new AisleDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    AisleNumber = a.AisleNumber,
                    Location = a.Location
                })
                .ToListAsync();
        }

        public async Task<AisleDto?> GetAisleByIdAsync(int id)
        {
            var aisle = await _context.Aisles.FindAsync(id);
            if (aisle == null) return null;

            return new AisleDto
            {
                Id = aisle.Id,
                Name = aisle.Name,
                Description = aisle.Description,
                AisleNumber = aisle.AisleNumber,
                Location = aisle.Location
            };
        }

        public async Task<AisleDto> CreateAisleAsync(CreateAisleDto createAisleDto)
        {
            var aisle = new Aisle
            {
                Name = createAisleDto.Name,
                Description = createAisleDto.Description,
                AisleNumber = createAisleDto.AisleNumber,
                Location = createAisleDto.Location
            };

            _context.Aisles.Add(aisle);
            await _context.SaveChangesAsync();

            return new AisleDto
            {
                Id = aisle.Id,
                Name = aisle.Name,
                Description = aisle.Description,
                AisleNumber = aisle.AisleNumber,
                Location = aisle.Location
            };
        }

        public async Task<AisleDto?> UpdateAisleAsync(int id, UpdateAisleDto updateAisleDto)
        {
            var aisle = await _context.Aisles.FindAsync(id);
            if (aisle == null) return null;

            aisle.Name = updateAisleDto.Name;
            aisle.Description = updateAisleDto.Description;
            aisle.AisleNumber = updateAisleDto.AisleNumber;
            aisle.Location = updateAisleDto.Location;

            await _context.SaveChangesAsync();

            return new AisleDto
            {
                Id = aisle.Id,
                Name = aisle.Name,
                Description = aisle.Description,
                AisleNumber = aisle.AisleNumber,
                Location = aisle.Location
            };
        }

        public async Task<bool> DeleteAisleAsync(int id)
        {
            var aisle = await _context.Aisles.FindAsync(id);
            if (aisle == null) return false;

            _context.Aisles.Remove(aisle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 