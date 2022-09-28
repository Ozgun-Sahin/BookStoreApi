using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model {get;set;}
        private readonly IBookStoreDbContext _context;

        public CreateAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=>x.Name == Model.Name);
            if(author is not null)
                throw new InvalidOperationException("Böyle bir yazar zaten mevcut.");
            
            author = new Author();
            author.Name = Model.Name;
            author.Surname = Model.Surname;
            author.DateOfBirth = Model.DateOfBirth;
            
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public class CreateAuthorModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}