using AutoMapper;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.UpdateBook;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

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

        }
    }
}