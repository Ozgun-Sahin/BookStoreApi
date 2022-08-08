using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using AutoMapper;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model {get; set;}
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public int BookId {get; set;}

        public UpdateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=> x.Id == BookId);

           if(book is null)
                throw new InvalidOperationException("Böyle bir kitap yok!");

            //UpdateBookModel vm = _mapper.Map<UpdateBookModel>(book);
            _mapper.Map(Model, book);
            //book = _mapper.Map<Book>(Model);
            // book.GenreId = Model.GenreId != default ? Model.GenreId: book.GenreId;
            // //book.PageCount = Model.PageCount != default ?Model.PageCount: book.PageCount;
            // book.Title = Model.Title != default ? Model.Title: book.Title;
            // //book.PublishDate = Model.PublishDate != default ? Model.PublishDate: book.PublishDate;

            await _dbContext.SaveChangesAsync();
        }

        public class UpdateBookModel
        {
            
            public string Title { get; set; }
            public int GenreId {get; set;}
            //public int PageCount {get; set;}
            //public DateTime PublishDate {get; set;}
        }
        
    } 
}