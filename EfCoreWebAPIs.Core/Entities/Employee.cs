using EfCoreWebAPIs.Core.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Core.Entities
{
    public class Employee : BaseEntity
    {
        public required  string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? Department { get; set; }

        [Precision(18, 2)]
        public decimal? Salary { get; set; }
    }
}
