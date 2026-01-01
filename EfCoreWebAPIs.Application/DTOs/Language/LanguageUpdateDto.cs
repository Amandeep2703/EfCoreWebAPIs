using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.DTOs.Language
{
    public class LanguageUpdateDto
    {
        [Required(ErrorMessage = "Language ID is required")]
        public Guid Id
        {
            get; set;
        }
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Description
        {
            get; set;
        }
        [MaxLength(10)]
        public string Code { get; set; } = string.Empty;

        public bool? IsActive { get; set; } = true;
    }
}
