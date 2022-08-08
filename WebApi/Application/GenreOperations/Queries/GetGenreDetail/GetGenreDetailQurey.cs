using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using System;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQurey 
    {
        public int GenreId { get; set; }
        public readonly BookStoreDbContext _context ;
        public readonly IMapper _mapper ;

        public GetGenreDetailQurey(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=> x.IsActive && x.Id == GenreId);
            if(genre is null)
                throw new InvalidOperationException("Kitap türü bulunamadı!");

            return _mapper.Map<GenreDetailViewModel>(genre);;
        }

        public class GenreDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }  
}