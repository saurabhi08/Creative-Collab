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

        // GET: api/authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        // GET: api/authors/5
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

        // POST: api/authors
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var author = await _authorService.CreateAuthorAsync(createAuthorDto);
            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        // PUT: api/authors/5
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

        // DELETE: api/authors/5
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