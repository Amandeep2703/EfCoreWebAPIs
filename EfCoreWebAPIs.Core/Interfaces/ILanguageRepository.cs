using EfCoreWebAPIs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Core.Interfaces
{
    public interface ILanguageRepository : IRepository<Language>
    {
        Task<Language?> GetLanguageWithBooksAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
