using AutoMapper;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using static WebApi.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=> ((GenreEnum)src.GenreId).ToString()));
            CreateMap<UpdateBookModel, Book>().ForMember(dest => dest.GenreId, opts => opts.MapFrom(src =>src.GenreId));
            CreateMap<UpdateBookModel, Book>().ForMember(dest => dest.Title, opts => opts.MapFrom(src =>src.Title));
            CreateMap<Genre, GenresViewModel>();

        }
    }
}