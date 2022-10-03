using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
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
        }
    }
}