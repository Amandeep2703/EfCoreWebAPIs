using EfCoreWebAPIs.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Core.Entities
{
    public class Book : BaseEntity
    {
        [Required(ErrorMessage ="Book title is requried")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Author name is required")]
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public string? Genre { get; set; }
        public int? Pages { get; set;}

        // Foreign key to Language
        public Guid? LanguageId
        {
            get; set;
        }

        //Navigation property
        public Language? Language
        {
            get; set;
        }
    }
}
