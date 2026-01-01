using EfCoreWebAPIs.Core.Interfaces;
using EfCoreWebAPIs.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _dbSet.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _dbSet.FindAsync([id], cancellationToken);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) =>
            await _dbSet.Where(predicate).AsNoTracking().ToListAsync(cancellationToken);

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default) =>
            await _dbSet.AddAsync(entity, cancellationToken);

        public void Update(T entity) => _dbSet.Update(entity);
        public void Remove(T entity) => _dbSet.Remove(entity);
    }
}
