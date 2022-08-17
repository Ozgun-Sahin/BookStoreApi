using AutoMapper;
using WebApi.Entities;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using static WebApi.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;
using static WebApi.Application.GenreOperations.Queries.GetGenreDetail.GetGenreDetailQurey;
using static WebApi.Application.BookOperations.Queries.GetBooks.GetBooksQuery;
using static WebApi.Application.AuthorOperations.Queries.GetAuthors.GetAuthorQuery;
using static WebApi.Application.AuthorOperations.Queries.GetAuthorDetail.GetAuthorDetailQuery;
using static WebApi.Application.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=> src.Genre.Name))
                                                    .ForMember(dest=> dest.Author, opt=> opt.MapFrom(src=> src.Author.Name));
            

            CreateMap<Book,BooksViewModel>().ForMember(dest=> dest.Genre, opt=> opt.MapFrom(src=> src.Genre.Name))
                                                .ForMember(dest=> dest.Author, opt=> opt.MapFrom(src=> src.Author.Name));

            CreateMap<UpdateBookModel, Book>().ForMember(dest => dest.GenreId, opts => opts.MapFrom(src =>src.GenreId))
                                                .ForMember(dest => dest.Title, opts => opts.MapFrom(src =>src.Title))
                                                .ForMember(dest => dest.AuthorId, opts => opts.MapFrom(src =>src.AuthorId));

            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();
            CreateMap<UpdateAuthorModel,Author>();
        }
    }
}