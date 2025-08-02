using Microsoft.EntityFrameworkCore;
using MindAndMarket.Data;
using MindAndMarket.DTOs;
using MindAndMarket.Models;

namespace MindAndMarket.Services
{
    public class ReadingSpotService : IReadingSpotService
    {
        private readonly MindAndMarketContext _context;

        public ReadingSpotService(MindAndMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReadingSpotDto>> GetAllReadingSpotsAsync()
        {
            return await _context.ReadingSpots
                .Select(r => new ReadingSpotDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    Location = r.Location,
                    Capacity = r.Capacity,
                    IsAvailable = r.IsAvailable,
                    Amenities = r.Amenities,
                    CreatedDate = r.CreatedDate
                })
                .ToListAsync();
        }

        public async Task<ReadingSpotDto?> GetReadingSpotByIdAsync(int id)
        {
            var readingSpot = await _context.ReadingSpots.FindAsync(id);
            if (readingSpot == null) return null;

            return new ReadingSpotDto
            {
                Id = readingSpot.Id,
                Name = readingSpot.Name,
                Description = readingSpot.Description,
                Location = readingSpot.Location,
                Capacity = readingSpot.Capacity,
                IsAvailable = readingSpot.IsAvailable,
                Amenities = readingSpot.Amenities,
                CreatedDate = readingSpot.CreatedDate
            };
        }

        public async Task<ReadingSpotDto> CreateReadingSpotAsync(CreateReadingSpotDto createReadingSpotDto)
        {
            var readingSpot = new ReadingSpot
            {
                Name = createReadingSpotDto.Name,
                Description = createReadingSpotDto.Description,
                Location = createReadingSpotDto.Location,
                Capacity = createReadingSpotDto.Capacity,
                IsAvailable = createReadingSpotDto.IsAvailable,
                Amenities = createReadingSpotDto.Amenities
            };

            _context.ReadingSpots.Add(readingSpot);
            await _context.SaveChangesAsync();

            return new ReadingSpotDto
            {
                Id = readingSpot.Id,
                Name = readingSpot.Name,
                Description = readingSpot.Description,
                Location = readingSpot.Location,
                Capacity = readingSpot.Capacity,
                IsAvailable = readingSpot.IsAvailable,
                Amenities = readingSpot.Amenities,
                CreatedDate = readingSpot.CreatedDate
            };
        }

        public async Task<ReadingSpotDto?> UpdateReadingSpotAsync(int id, UpdateReadingSpotDto updateReadingSpotDto)
        {
            var readingSpot = await _context.ReadingSpots.FindAsync(id);
            if (readingSpot == null) return null;

            readingSpot.Name = updateReadingSpotDto.Name;
            readingSpot.Description = updateReadingSpotDto.Description;
            readingSpot.Location = updateReadingSpotDto.Location;
            readingSpot.Capacity = updateReadingSpotDto.Capacity;
            readingSpot.IsAvailable = updateReadingSpotDto.IsAvailable;
            readingSpot.Amenities = updateReadingSpotDto.Amenities;

            await _context.SaveChangesAsync();

            return new ReadingSpotDto
            {
                Id = readingSpot.Id,
                Name = readingSpot.Name,
                Description = readingSpot.Description,
                Location = readingSpot.Location,
                Capacity = readingSpot.Capacity,
                IsAvailable = readingSpot.IsAvailable,
                Amenities = readingSpot.Amenities,
                CreatedDate = readingSpot.CreatedDate
            };
        }

        public async Task<bool> DeleteReadingSpotAsync(int id)
        {
            var readingSpot = await _context.ReadingSpots.FindAsync(id);
            if (readingSpot == null) return false;

            _context.ReadingSpots.Remove(readingSpot);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 