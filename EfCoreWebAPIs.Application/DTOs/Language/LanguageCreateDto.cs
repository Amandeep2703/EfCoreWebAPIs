using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.DTOs.Language
{
    public class LanguageCreateDto
    {
        [Required(ErrorMessage = "Language title is required")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Description
        {
            get; set;
        }

        [Required(ErrorMessage = "Language code is required")]
        [MaxLength(10)]
        public string Code { get; set; } = string.Empty;
    }
}
