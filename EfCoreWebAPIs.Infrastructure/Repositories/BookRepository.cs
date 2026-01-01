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
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context) : base(context) { 
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksWithLanguageAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Books
                .Include(b => b.Language)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Book>> GetActiveBooksAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Books
                .Where(b => b.IsActive == true && b.IsDeleted == false)
                .Include(b => b.Language)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
