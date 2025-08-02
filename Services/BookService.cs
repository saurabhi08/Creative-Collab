using Microsoft.EntityFrameworkCore;
using MindAndMarket.Data;
using MindAndMarket.DTOs;
using MindAndMarket.Models;

namespace MindAndMarket.Services
{
    public class BookService : IBookService
    {
        private readonly MindAndMarketContext _context;

        public BookService(MindAndMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    ISBN = b.ISBN,
                    PublicationDate = b.PublicationDate,
                    Price = b.Price,
                    StockQuantity = b.StockQuantity,
                    AuthorName = b.Author.Name,
                    CategoryName = b.Category.Name
                })
                .ToListAsync();
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                ISBN = book.ISBN,
                PublicationDate = book.PublicationDate,
                Price = book.Price,
                StockQuantity = book.StockQuantity,
                AuthorName = book.Author.Name,
                CategoryName = book.Category.Name
            };
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            var book = new Book
            {
                Title = createBookDto.Title,
                Description = createBookDto.Description,
                ISBN = createBookDto.ISBN,
                PublicationDate = createBookDto.PublicationDate,
                Price = createBookDto.Price,
                StockQuantity = createBookDto.StockQuantity,
                AuthorId = createBookDto.AuthorId,
                CategoryId = createBookDto.CategoryId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return await GetBookByIdAsync(book.Id) ?? new BookDto();
        }

        public async Task<BookDto?> UpdateBookAsync(int id, UpdateBookDto updateBookDto)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return null;

            book.Title = updateBookDto.Title;
            book.Description = updateBookDto.Description;
            book.ISBN = updateBookDto.ISBN;
            book.PublicationDate = updateBookDto.PublicationDate;
            book.Price = updateBookDto.Price;
            book.StockQuantity = updateBookDto.StockQuantity;
            book.AuthorId = updateBookDto.AuthorId;
            book.CategoryId = updateBookDto.CategoryId;

            await _context.SaveChangesAsync();

            return await GetBookByIdAsync(id);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

        // Combined features
        public async Task<IEnumerable<BookDto>> GetBooksForProductAsync(int productId)
        {
            var product = await _context.Products
                .Include(p => p.RelatedBooks)
                .ThenInclude(b => b.Author)
                .Include(p => p.RelatedBooks)
                .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null) return new List<BookDto>();

            return product.RelatedBooks.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                ISBN = b.ISBN,
                PublicationDate = b.PublicationDate,
                Price = b.Price,
                StockQuantity = b.StockQuantity,
                AuthorName = b.Author.Name,
                CategoryName = b.Category.Name
            });
        }

        public async Task<IEnumerable<ProductDto>> GetProductsForBookAsync(int bookId)
        {
            var book = await _context.Books
                .Include(b => b.RelatedProducts)
                .ThenInclude(p => p.Aisle)
                .Include(b => b.RelatedProducts)
                .ThenInclude(p => p.Department)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null) return new List<ProductDto>();

            return book.RelatedProducts.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                SKU = p.SKU,
                IsOrganic = p.IsOrganic,
                IsGlutenFree = p.IsGlutenFree,
                AisleName = p.Aisle.Name,
                DepartmentName = p.Department.Name
            });
        }

        public async Task<bool> AddBookToProductAsync(int bookId, int productId)
        {
            var book = await _context.Books.FindAsync(bookId);
            var product = await _context.Products.FindAsync(productId);

            if (book == null || product == null) return false;

            book.RelatedProducts.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveBookFromProductAsync(int bookId, int productId)
        {
            var book = await _context.Books
                .Include(b => b.RelatedProducts)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null) return false;

            var product = book.RelatedProducts.FirstOrDefault(p => p.Id == productId);
            if (product == null) return false;

            book.RelatedProducts.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BookDto>> GetBooksForDepartmentAsync(int departmentId)
        {
            var department = await _context.Departments
                .Include(d => d.RelatedBooks)
                .ThenInclude(b => b.Author)
                .Include(d => d.RelatedBooks)
                .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(d => d.Id == departmentId);

            if (department == null) return new List<BookDto>();

            return department.RelatedBooks.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                ISBN = b.ISBN,
                PublicationDate = b.PublicationDate,
                Price = b.Price,
                StockQuantity = b.StockQuantity,
                AuthorName = b.Author.Name,
                CategoryName = b.Category.Name
            });
        }

        public async Task<bool> AddBookToDepartmentAsync(int bookId, int departmentId)
        {
            var book = await _context.Books.FindAsync(bookId);
            var department = await _context.Departments.FindAsync(departmentId);

            if (book == null || department == null) return false;

            book.RelatedDepartments.Add(department);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveBookFromDepartmentAsync(int bookId, int departmentId)
        {
            var book = await _context.Books
                .Include(b => b.RelatedDepartments)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null) return false;

            var department = book.RelatedDepartments.FirstOrDefault(d => d.Id == departmentId);
            if (department == null) return false;

            book.RelatedDepartments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BookDto>> GetBooksForEventAsync(int eventId)
        {
            var eventEntity = await _context.Events
                .Include(e => e.RelatedBooks)
                .ThenInclude(b => b.Author)
                .Include(e => e.RelatedBooks)
                .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(e => e.Id == eventId);

            if (eventEntity == null) return new List<BookDto>();

            return eventEntity.RelatedBooks.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                ISBN = b.ISBN,
                PublicationDate = b.PublicationDate,
                Price = b.Price,
                StockQuantity = b.StockQuantity,
                AuthorName = b.Author.Name,
                CategoryName = b.Category.Name
            });
        }

        public async Task<bool> AddBookToEventAsync(int bookId, int eventId)
        {
            var book = await _context.Books.FindAsync(bookId);
            var eventEntity = await _context.Events.FindAsync(eventId);

            if (book == null || eventEntity == null) return false;

            book.Events.Add(eventEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveBookFromEventAsync(int bookId, int eventId)
        {
            var book = await _context.Books
                .Include(b => b.Events)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null) return false;

            var eventEntity = book.Events.FirstOrDefault(e => e.Id == eventId);
            if (eventEntity == null) return false;

            book.Events.Remove(eventEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 