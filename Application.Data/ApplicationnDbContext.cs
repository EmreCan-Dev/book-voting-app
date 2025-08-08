using Application.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    public class ApplicationnDbContext:DbContext
    {
        public ApplicationnDbContext(DbContextOptions<ApplicationnDbContext> options):base(options){}

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        
        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<VoteEntity> Votes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }

  }
