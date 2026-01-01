using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.DTOs.Language
{
    public class LanguageResponseDto
    {
        public Guid Id
        {
            get; set;
        }

        public string Title { get; set; } = string.Empty;
        public string? Description
        {
            get; set;
        }
        public string Code { get; set; } = string.Empty;

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

        // Optional: include list of book titles if needed for read operations
        public ICollection<string>? BookTitles
        {
            get; set;
        }
    }
}
