using EfCoreWebAPIs.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                   .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(b => b.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(b => b.Author)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(b => b.ISBN)
                   .HasMaxLength(50);

            builder.Property(b => b.Genre)
                   .HasMaxLength(100);

            // Relationship configuration
            builder.HasOne(b => b.Language)
                   .WithMany(l => l.Books)
                   .HasForeignKey(b => b.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
