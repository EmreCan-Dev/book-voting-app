using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Entities
{
    public class VoteEntity
    {
        public int Id { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public BookEntity Book { get; set; }
    }

    public class VoteEntityConfiguration:IEntityTypeConfiguration<VoteEntity>
    {
        public void Configure(EntityTypeBuilder<VoteEntity> builder)
        {
            builder.HasKey(v=>v.Id);
            builder.HasOne(v => v.User).WithMany(v => v.UserVotes).HasForeignKey(v => v.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(v => v.Book).WithMany(v => v.BookVotes).HasForeignKey(v => v.BookId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
