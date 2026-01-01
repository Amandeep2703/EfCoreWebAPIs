using EfCoreWebAPIs.Application.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<BookResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<BookResponseDto> CreateAsync(BookCreateDto dto, CancellationToken cancellationToken = default);
        Task<BookResponseDto> UpdateAsync(BookUpdateDto dto, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<BookResponseDto>> GetBooksWithLanguagesAsync(CancellationToken cancellationToken = default);
    }
}
