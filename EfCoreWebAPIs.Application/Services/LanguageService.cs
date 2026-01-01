using AutoMapper;
using EfCoreWebAPIs.Application.DTOs.Language;
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
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LanguageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LanguageResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var languages = await _unitOfWork.Repository<Language>().GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<LanguageResponseDto>>(languages);
        }

        public async Task<LanguageResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var language = await _unitOfWork.Repository<Language>().GetByIdAsync(id, cancellationToken);
            return language == null ? null : _mapper.Map<LanguageResponseDto>(language);
        }

        public async Task<LanguageResponseDto> CreateAsync(LanguageCreateDto dto, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<Language>(dto);
            entity.CreatedOn = DateTime.UtcNow;
            entity.IsActive = true;

            await _unitOfWork.Repository<Language>().AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<LanguageResponseDto>(entity);
        }

        public async Task<LanguageResponseDto> UpdateAsync(LanguageUpdateDto dto, CancellationToken cancellationToken = default)
        {
            var repo = _unitOfWork.Repository<Language>();
            var entity = await repo.GetByIdAsync(dto.Id, cancellationToken);

            if (entity == null)
                throw new KeyNotFoundException("Language not found");

            _mapper.Map(dto, entity); // only updates non-null fields
            entity.UpdatedOn = DateTime.UtcNow;

            repo.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<LanguageResponseDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var repo = _unitOfWork.Repository<Language>();
            var entity = await repo.GetByIdAsync(id, cancellationToken);

            if (entity == null)
                return false;

            repo.Remove(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
