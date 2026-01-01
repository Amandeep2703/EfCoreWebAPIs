using AutoMapper;
using EfCoreWebAPIs.Application.DTOs.Book;
using EfCoreWebAPIs.Application.Interfaces;
using EfCoreWebAPIs.Core.Entities;
using EfCoreWebAPIs.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var books = await _unitOfWork.Repository<Book>().GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<BookResponseDto>>(books);
        }

        public async Task<BookResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var book = await _unitOfWork.Repository<Book>().GetByIdAsync(id, cancellationToken);
            return book == null ? null : _mapper.Map<BookResponseDto>(book);
        }

        public async Task<BookResponseDto> CreateAsync(BookCreateDto dto, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<Book>(dto);
            entity.CreatedOn = DateTime.UtcNow;
            entity.IsActive = true;

            await _unitOfWork.Repository<Book>().AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<BookResponseDto>(entity);
        }

        public async Task<BookResponseDto> UpdateAsync(BookUpdateDto dto, CancellationToken cancellationToken = default)
        {
            var repo = _unitOfWork.Repository<Book>();
            var entity = await repo.GetByIdAsync(dto.Id, cancellationToken);

            if (entity == null)
                throw new KeyNotFoundException("Book not found");

            _mapper.Map(dto, entity);
            entity.UpdatedOn = DateTime.UtcNow;

            repo.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<BookResponseDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var repo = _unitOfWork.Repository<Book>();
            var entity = await repo.GetByIdAsync(id, cancellationToken);

            if (entity == null)
                return false;

            repo.Remove(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BookResponseDto>> GetBooksWithLanguagesAsync(CancellationToken cancellationToken = default)
        {
            var books = await _unitOfWork.BookRepository.GetBooksWithLanguageAsync(cancellationToken);
            return _mapper.Map<IEnumerable<BookResponseDto>>(books);
        }

        public async Task<IEnumerable<BookResponseDto>> GetActiveBooksAsync(CancellationToken cancellationToken = default)
        {
            var books = await _unitOfWork.BookRepository.GetActiveBooksAsync(cancellationToken);
            return _mapper.Map<IEnumerable<BookResponseDto>>(books);
        }
    }
}
