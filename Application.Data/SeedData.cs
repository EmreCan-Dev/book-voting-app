using Application.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    public static class SeedData
    {
       public static async Task SeedAsync(this ApplicationnDbContext context)
       {
            var anyUsers = await context.Users.AnyAsync();
            var anyBooks = await context.Books.AnyAsync();

            if (anyUsers || anyBooks)
            {
                return;
            }

            var adminRole = new RoleEntity
                {
                    Name = "Admin"
                };
                var userRole = new RoleEntity
                {
                    Name = "User"
                };

                context.Roles.AddRange(adminRole, userRole);
                await context.SaveChangesAsync();

                var userAdmin = new UserEntity
                {
                    Name = "Mahmut",
                    Email="mahmut@mahmut.com",
                    Password="mahmut123",
                    RoleId=adminRole.Id
                };

                var user2 = new UserEntity
                {
                    Name = "Emre",
                    Email = "emre@emre.com",
                    Password="emre123",
                    RoleId=userRole.Id
                };

                context.Users.AddRange(userAdmin,user2);
                await context.SaveChangesAsync();

                var classicCategory = new CategoryEntity
                {
                    Name = "Klasikler"
                };

                var sciFiCategory = new CategoryEntity
                {
                    Name = "Bilim kurgu"
                };

                context.Categories.AddRange(sciFiCategory,classicCategory);
                await context.SaveChangesAsync();

            var books = new List<BookEntity>
{
    new BookEntity { Title = "Sefiller", Author = "Victor Hugo", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Suç ve Ceza", Author = "Fyodor Dostoyevski", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Karamazov Kardeşler", Author = "Fyodor Dostoyevski", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Vadideki Zambak", Author = "Honoré de Balzac", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Yabancı", Author = "Albert Camus", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Körlük", Author = "José Saramago", CategoryId = classicCategory.Id },
    new BookEntity { Title = "İnsan Neyle Yaşar", Author = "Lev Tolstoy", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Satranç", Author = "Stefan Zweig", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Amok Koşucusu", Author = "Stefan Zweig", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Martı", Author = "Richard Bach", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Dönüşüm", Author = "Franz Kafka", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Savaş ve Barış", Author = "Lev Tolstoy", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Beyaz Diş", Author = "Jack London", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Bilinmeyen Bir Kadının Mektubu", Author = "Stefan Zweig", CategoryId = classicCategory.Id },
    new BookEntity { Title = "İki Şehrin Hikayesi", Author = "Charles Dickens", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Jane Eyre", Author = "Charlotte Brontë", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Gurur ve Önyargı", Author = "Jane Austen", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Bülbülü Öldürmek", Author = "Harper Lee", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Küçük Prens", Author = "Antoine de Saint-Exupéry", CategoryId = classicCategory.Id },
    new BookEntity { Title = "Yeraltından Notlar", Author = "Fyodor Dostoyevski", CategoryId = classicCategory.Id },

    new BookEntity { Title = "1984", Author = "George Orwell", CategoryId = sciFiCategory.Id },
    new BookEntity { Title = "Hayvan Çiftliği", Author = "George Orwell", CategoryId = sciFiCategory.Id },
    new BookEntity { Title = "Simyacı", Author = "Paulo Coelho", CategoryId = sciFiCategory.Id },
    new BookEntity { Title = "Otostopçunun Galaksi Rehberi", Author = "Douglas Adams", CategoryId = sciFiCategory.Id },
    new BookEntity { Title = "Dune", Author = "Frank Herbert", CategoryId = sciFiCategory.Id },
    new BookEntity { Title = "Fahrenheit 451", Author = "Ray Bradbury", CategoryId = sciFiCategory.Id },
    new BookEntity { Title = "Cesur Yeni Dünya", Author = "Aldous Huxley", CategoryId = sciFiCategory.Id },
    new BookEntity { Title = "Zaman Makinesi", Author = "H.G. Wells", CategoryId = sciFiCategory.Id },
    new BookEntity { Title = "Dr. Jekyll ve Mr. Hyde", Author = "Robert Louis Stevenson", CategoryId = sciFiCategory.Id },
    new BookEntity { Title = "Frankenstein", Author = "Mary Shelley", CategoryId = sciFiCategory.Id }
};

            context.Books.AddRange(books);

            await context.SaveChangesAsync();

                

               
                
            
       }
    }
}
