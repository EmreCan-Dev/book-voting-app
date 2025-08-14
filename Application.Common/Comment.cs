using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class Comment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(c => c.Book).WithMany(b => b.BookComments).HasForeignKey(b => b.BookId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.Author).WithMany(b => b.AuthorComments).HasForeignKey(b => b.AuthorId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.User).WithMany(c => c.UserComments).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
