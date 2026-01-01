using EfCoreWebAPIs.Application.DTOs.Language;
using EfCoreWebAPIs.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _languageService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _languageService.GetByIdAsync(id, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LanguageCreateDto dto, CancellationToken cancellationToken)
        {
            var result = await _languageService.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new
            {
                id = result.Id
            }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LanguageUpdateDto dto, CancellationToken cancellationToken)
        {
            var result = await _languageService.UpdateAsync(dto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var deleted = await _languageService.DeleteAsync(id, cancellationToken);
            return deleted ? NoContent() : NotFound();
        }
    }
}
