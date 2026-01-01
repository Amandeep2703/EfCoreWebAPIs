using EfCoreWebAPIs.Core.Common;
using EfCoreWebAPIs.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sequential GUID for better performance
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                     .Where(t => typeof(BaseEntity).IsAssignableFrom(t.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType)
                            .Property(nameof(BaseEntity.Id))
                            .HasDefaultValueSql("NEWSEQUENTIALID()");
            }

            // Global soft delete filter
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                     .Where(t => typeof(BaseEntity).IsAssignableFrom(t.ClrType)))
            {
                var method = typeof(AppDbContext).GetMethod(nameof(ApplySoftDeleteFilter),
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                    ?.MakeGenericMethod(entityType.ClrType);
                method?.Invoke(null, new object[] { modelBuilder });
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<Employee>().ToTable("Employees");
            

        }

        private static void ApplySoftDeleteFilter<TEntity>(ModelBuilder builder)
            where TEntity : BaseEntity =>
            builder.Entity<TEntity>().HasQueryFilter(e => e.IsDeleted == false || e.IsDeleted == null);

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            var now = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedOn = now;
                else if (entry.State == EntityState.Modified)
                    entry.Entity.UpdatedOn = now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }


    }
}