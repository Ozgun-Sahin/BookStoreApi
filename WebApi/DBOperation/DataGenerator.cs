using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre{
                        Name = "Horror"

                    },
                    new Genre{
                        Name = "Graphic Novel"

                    },
                    new Genre{
                        Name = "Sci-fi"

                    }
                );

                context.Authors.AddRange(
                    new Author{
                        Name = "Stephen",
                        Surname ="King",
                        DateOfBirth = new DateTime(1947,09,21)
                    },

                    new Author{
                        Name = "Nail",
                        Surname ="Gaiman",
                        DateOfBirth = new DateTime(1960,11,10)
                    },

                    new Author{
                        Name = "Aldous",
                        Surname ="Huxley",
                        DateOfBirth = new DateTime(1894,07,26)
                    }
                );
                    
                context.Books.AddRange(
                    new Book 
                    {
                        //Id = 1,
                        Title = "Hayvan Mezarlığı",
                        GenreId = 1, 
                        PageCount = 200,
                        PublishDate = new DateTime(2001,06,12),
                        AuthorId = 1
                    },

                    new Book 
                    {
                        //Id = 2,
                        Title = "Sandman",
                        GenreId = 2, 
                        PageCount = 250,
                        PublishDate = new DateTime(2020,05,23),
                        AuthorId = 2
                    },

                    new Book 
                    {
                        //Id = 3,
                        Title = "Brave New World",
                        GenreId = 2,
                        PageCount = 540,
                        PublishDate = new DateTime(2001,12,21),
                        AuthorId =3
                    }

                );

                context.SaveChanges();
            }
        }
    }
}