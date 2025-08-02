using MindAndMarket.DTOs;
using MindAndMarket.Models;

namespace MindAndMarket.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto?> GetBookByIdAsync(int id);
        Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);
        Task<BookDto?> UpdateBookAsync(int id, UpdateBookDto updateBookDto);
        Task<bool> DeleteBookAsync(int id);
        
        // Combined features
        Task<IEnumerable<BookDto>> GetBooksForProductAsync(int productId);
        Task<IEnumerable<ProductDto>> GetProductsForBookAsync(int bookId);
        Task<bool> AddBookToProductAsync(int bookId, int productId);
        Task<bool> RemoveBookFromProductAsync(int bookId, int productId);
        
        Task<IEnumerable<BookDto>> GetBooksForDepartmentAsync(int departmentId);
        Task<bool> AddBookToDepartmentAsync(int bookId, int departmentId);
        Task<bool> RemoveBookFromDepartmentAsync(int bookId, int departmentId);
        
        Task<IEnumerable<BookDto>> GetBooksForEventAsync(int eventId);
        Task<bool> AddBookToEventAsync(int bookId, int eventId);
        Task<bool> RemoveBookFromEventAsync(int bookId, int eventId);
    }
} 