using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
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
        }
    }
}