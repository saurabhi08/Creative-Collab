using Microsoft.EntityFrameworkCore;
using MindAndMarket.Data;
using MindAndMarket.DTOs;
using MindAndMarket.Models;

namespace MindAndMarket.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly MindAndMarketContext _context;

        public AuthorService(MindAndMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            return await _context.Authors
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Biography = a.Biography,
                    Nationality = a.Nationality,
                    BirthDate = a.BirthDate
                })
                .ToListAsync();
        }

        public async Task<AuthorDto?> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return null;

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                Nationality = author.Nationality,
                BirthDate = author.BirthDate
            };
        }

        public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            var author = new Author
            {
                Name = createAuthorDto.Name,
                Biography = createAuthorDto.Biography,
                Nationality = createAuthorDto.Nationality,
                BirthDate = createAuthorDto.BirthDate
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                Nationality = author.Nationality,
                BirthDate = author.BirthDate
            };
        }

        public async Task<AuthorDto?> UpdateAuthorAsync(int id, UpdateAuthorDto updateAuthorDto)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return null;

            author.Name = updateAuthorDto.Name;
            author.Biography = updateAuthorDto.Biography;
            author.Nationality = updateAuthorDto.Nationality;
            author.BirthDate = updateAuthorDto.BirthDate;

            await _context.SaveChangesAsync();

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                Nationality = author.Nationality,
                BirthDate = author.BirthDate
            };
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return false;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 