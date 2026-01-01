using AutoMapper;
using EfCoreWebAPIs.Application.DTOs.Book;
using EfCoreWebAPIs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            // ✅ Book ↔ BookResponseDto
            CreateMap<Book, BookResponseDto>().ReverseMap();

            // ✅ Book ↔ BookCreateDto
            CreateMap<Book, BookCreateDto>().ReverseMap();

            // ✅ Book ↔ BookUpdateDto
            // and only update fields that are non-null
            CreateMap<Book, BookUpdateDto>()
                .ReverseMap()
                .ForAllMembers(opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
