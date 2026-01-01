using EfCoreWebAPIs.Application.DTOs.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.Interfaces
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<LanguageResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<LanguageResponseDto> CreateAsync(LanguageCreateDto dto, CancellationToken cancellationToken = default);
        Task<LanguageResponseDto> UpdateAsync(LanguageUpdateDto dto, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
