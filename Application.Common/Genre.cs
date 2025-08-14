using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(g => g.Category).WithMany(g => g.Genres).HasForeignKey(g => g.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(g => g.Book).WithMany(g => g.BookGenres).HasForeignKey(g => g.BookId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(nameof(Genre.Name)).HasMaxLength(30).IsRequired();
        }
    }
}
