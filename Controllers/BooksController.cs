using Microsoft.AspNetCore.Mvc;
using MindAndMarket.DTOs;
using MindAndMarket.Services;

namespace MindAndMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(CreateBookDto createBookDto)
        {
            var book = await _bookService.CreateBookAsync(createBookDto);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookDto updateBookDto)
        {
            var book = await _bookService.UpdateBookAsync(id, updateBookDto);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Combined Features

        // GET: api/books/for-product/5
        [HttpGet("for-product/{productId}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksForProduct(int productId)
        {
            var books = await _bookService.GetBooksForProductAsync(productId);
            return Ok(books);
        }

        // GET: api/books/5/products
        [HttpGet("{bookId}/products")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsForBook(int bookId)
        {
            var products = await _bookService.GetProductsForBookAsync(bookId);
            return Ok(products);
        }

        // POST: api/books/5/products/10
        [HttpPost("{bookId}/products/{productId}")]
        public async Task<IActionResult> AddBookToProduct(int bookId, int productId)
        {
            var result = await _bookService.AddBookToProductAsync(bookId, productId);
            if (!result)
            {
                return BadRequest("Failed to link book to product");
            }
            return Ok();
        }

        // DELETE: api/books/5/products/10
        [HttpDelete("{bookId}/products/{productId}")]
        public async Task<IActionResult> RemoveBookFromProduct(int bookId, int productId)
        {
            var result = await _bookService.RemoveBookFromProductAsync(bookId, productId);
            if (!result)
            {
                return BadRequest("Failed to unlink book from product");
            }
            return NoContent();
        }

        // GET: api/books/for-department/5
        [HttpGet("for-department/{departmentId}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksForDepartment(int departmentId)
        {
            var books = await _bookService.GetBooksForDepartmentAsync(departmentId);
            return Ok(books);
        }

        // POST: api/books/5/departments/10
        [HttpPost("{bookId}/departments/{departmentId}")]
        public async Task<IActionResult> AddBookToDepartment(int bookId, int departmentId)
        {
            var result = await _bookService.AddBookToDepartmentAsync(bookId, departmentId);
            if (!result)
            {
                return BadRequest("Failed to link book to department");
            }
            return Ok();
        }

        // DELETE: api/books/5/departments/10
        [HttpDelete("{bookId}/departments/{departmentId}")]
        public async Task<IActionResult> RemoveBookFromDepartment(int bookId, int departmentId)
        {
            var result = await _bookService.RemoveBookFromDepartmentAsync(bookId, departmentId);
            if (!result)
            {
                return BadRequest("Failed to unlink book from department");
            }
            return NoContent();
        }

        // GET: api/books/for-event/5
        [HttpGet("for-event/{eventId}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksForEvent(int eventId)
        {
            var books = await _bookService.GetBooksForEventAsync(eventId);
            return Ok(books);
        }

        // POST: api/books/5/events/10
        [HttpPost("{bookId}/events/{eventId}")]
        public async Task<IActionResult> AddBookToEvent(int bookId, int eventId)
        {
            var result = await _bookService.AddBookToEventAsync(bookId, eventId);
            if (!result)
            {
                return BadRequest("Failed to link book to event");
            }
            return Ok();
        }

        // DELETE: api/books/5/events/10
        [HttpDelete("{bookId}/events/{eventId}")]
        public async Task<IActionResult> RemoveBookFromEvent(int bookId, int eventId)
        {
            var result = await _bookService.RemoveBookFromEventAsync(bookId, eventId);
            if (!result)
            {
                return BadRequest("Failed to unlink book from event");
            }
            return NoContent();
        }
    }
} 