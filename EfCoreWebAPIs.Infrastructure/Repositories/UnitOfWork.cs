using EfCoreWebAPIs.Core.Interfaces;
using EfCoreWebAPIs.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        // ✅ Expose specific repositories
        public IBookRepository BookRepository
        {
            get;
        }
        public ILanguageRepository LanguageRepository
        {
            get;
        }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            // Initialize specialized repositories
            BookRepository = new BookRepository(_context);
            LanguageRepository = new LanguageRepository(_context);
        }

        // ✅ Still keep generic repository support
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];

            var repo = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repo);
            return repo;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}

