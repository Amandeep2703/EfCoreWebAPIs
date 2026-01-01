using EfCoreWebAPIs.Application.DTOs.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.DTOs.Book
{
    public class BookResponseDto
    {
        public Guid Id
        {
            get; set;
        }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? ISBN
        {
            get; set;
        }
        public string? Genre
        {
            get; set;
        }
        public int? Pages
        {
            get; set;
        }

        public Guid LanguageId
        {
            get; set;
        }

        public LanguageResponseDto? Language
        {
            get; set;
        } // ✅ Full Language object

        public DateTime? CreatedOn
        {
            get; set;
        }
        public string? CreatedBy
        {
            get; set;
        }
        public DateTime? UpdatedOn
        {
            get; set;
        }
        public string? UpdatedBy
        {
            get; set;
        }

        public bool? IsActive
        {
            get; set;
        }
        public bool? IsDeleted
        {
            get; set;
        }
    }
}
