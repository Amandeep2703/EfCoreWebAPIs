using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.DTOs.Book
{
    public class BookCreateDto
    {
        [Required(ErrorMessage = "Book title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author name is required")]
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

        public Guid? LanguageId
        {
            get; set;
        }
    }
}
