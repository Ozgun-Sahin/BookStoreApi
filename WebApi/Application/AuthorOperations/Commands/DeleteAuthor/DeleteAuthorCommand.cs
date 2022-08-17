using System;
using System.Linq;
using WebApi.DBOperations;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Id == AuthorId);
            var book = _context.Books.SingleOrDefault(x=> x.AuthorId==AuthorId);

            if(author is null)
                throw new InvalidOperationException("Silinecek yazar bulunamadı!");
            if(book is not null)
                throw new InvalidOperationException("Silinecek Yazarın Kitabı Hala Yayında");
                
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
