using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class Vote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
    public class VoteConfiguration:IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.User).WithMany(p => p.UserVotes).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Book).WithMany(p => p.BookVotes).HasForeignKey(p => p.BookId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Author).WithMany(p => p.AuthorVotes).HasForeignKey(p => p.AuthorId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
