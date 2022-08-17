using AutoMapper;
using WebApi.DBOperations;
using System.Linq;
using System;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetAuthorQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var authorList = _context.Authors.OrderBy(x=> x.Id).ToList<Author>();
            List<AuthorViewModel> vm = _mapper.Map<List<AuthorViewModel>>(authorList);
            return vm; 
        }


        public class AuthorViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime DateOfBirth { get; set; }
        } 
    }

}