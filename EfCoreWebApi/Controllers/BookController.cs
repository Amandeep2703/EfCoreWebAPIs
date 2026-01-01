using EfCoreWebAPIs.Application.DTOs.Book;
using EfCoreWebAPIs.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreWebApi.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _bookService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("BookWithLangage")]
        public async Task<IActionResult> GetBookWithLanguages(CancellationToken cancellationToken)
        {
            var res = await _bookService.GetBooksWithLanguagesAsync(cancellationToken);

            if (res is not null)
            {
                return Ok(res);
            }
            return NotFound("No books");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _bookService.GetByIdAsync(id, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCreateDto dto, CancellationToken cancellationToken)
        {
            var result = await _bookService.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new
            {
                id = result.Id
            }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BookUpdateDto dto, CancellationToken cancellationToken)
        {
            var result = await _bookService.UpdateAsync(dto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var deleted = await _bookService.DeleteAsync(id, cancellationToken);
            return deleted ? NoContent() : NotFound();
        }

    }

}
