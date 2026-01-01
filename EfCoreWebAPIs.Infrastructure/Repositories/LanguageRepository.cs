using EfCoreWebAPIs.Core.Entities;
using EfCoreWebAPIs.Core.Interfaces;
using EfCoreWebAPIs.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Infrastructure.Repositories
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        private readonly AppDbContext _context;
        public LanguageRepository(AppDbContext context) : base(context) {
               _context = context;
        }

        public async Task<Language?> GetLanguageWithBooksAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Languages
                .Include(l => l.Books)
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
        }
    }
}
