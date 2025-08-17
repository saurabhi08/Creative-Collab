using Microsoft.AspNetCore.Mvc;
using MindAndMarket.DTOs;
using MindAndMarket.Services;

namespace MindAndMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Retrieves all authors.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        /// <summary>
        /// Retrieves a single author by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        /// <summary>
        /// Creates a new author.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var author = await _authorService.CreateAuthorAsync(createAuthorDto);
            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        /// <summary>
        /// Updates an existing author by ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorDto updateAuthorDto)
        {
            var author = await _authorService.UpdateAuthorAsync(id, updateAuthorDto);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        /// <summary>
        /// Deletes an author by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _authorService.DeleteAuthorAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
} 