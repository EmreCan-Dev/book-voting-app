using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public  class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<Vote>? BookVotes { get; set; }
        public ICollection<Genre> BookGenres { get; set; } = null!;
        public ICollection<Comment>? BookComments { get; set; }
    }
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(nameof(Book.Name)).HasMaxLength(50).IsRequired();
            builder.HasOne(b => b.Category).WithMany(b => b.Books).HasForeignKey(b => b.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(b => b.Author).WithMany(b => b.AuthorBooks).HasForeignKey(b => b.AuthorId).OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
