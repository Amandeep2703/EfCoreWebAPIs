using EfCoreWebAPIs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Core.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksWithLanguageAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Book>> GetActiveBooksAsync(CancellationToken cancellationToken = default);
    }
}
