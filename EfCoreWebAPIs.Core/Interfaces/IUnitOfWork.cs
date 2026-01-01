using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Generic repository access (still supported)
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        // Specific repositories
        IBookRepository BookRepository
        {
            get;
        }
        ILanguageRepository LanguageRepository
        {
            get;
        }

        // Commit transaction
        Task<int> SaveChangesAsync();
    }
}
