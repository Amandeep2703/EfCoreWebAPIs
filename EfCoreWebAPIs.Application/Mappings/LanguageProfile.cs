using AutoMapper;
using EfCoreWebAPIs.Application.DTOs.Language;
using EfCoreWebAPIs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.Mappings
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            // ✅ Language ↔ LanguageResponseDto
            CreateMap<Language, LanguageResponseDto>()
                .ForMember(dest => dest.BookTitles,
                    opt => opt.MapFrom(src => src.Books.Select(b => b.Title)))
                .ReverseMap();

            // ✅ Language ↔ LanguageCreateDto
            CreateMap<Language, LanguageCreateDto>().ReverseMap();

            // ✅ Language ↔ LanguageUpdateDto (partial update enabled)
            CreateMap<Language, LanguageUpdateDto>()
                .ReverseMap()
                .ForAllMembers(opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
