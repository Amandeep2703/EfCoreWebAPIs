using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.DTOs.Book
{
    public class BookUpdateDto
    {
        [Required(ErrorMessage = "Book ID is required")]
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

        public bool? IsActive { get; set; } = true;
    }
}
