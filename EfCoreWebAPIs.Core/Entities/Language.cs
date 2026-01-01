using EfCoreWebAPIs.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Core.Entities
{
    public class Language : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        //Navigation property for one-to-many relationship
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
