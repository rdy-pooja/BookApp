using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Models;

namespace BookApp
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }
        public List<Book> GetBooks()
        {
            List<Book> books = _context.Books.ToList<Book>();
            return books;
        }
        public Book GetBookByID(string ID)
        {
            return _context.Books.Where(x => x.ID == ID).FirstOrDefault();
        }
        public bool AddBook(Book book)
        {
            Guid obj = Guid.NewGuid();
            book.ID = obj.ToString();
            _context.Books.Add(book);
            if (_context.SaveChanges() != 0)
            {
                return true;
            }
            return false;
        }
        public bool ModifyBookDetails(string ID, Book book)
        {
            Book temp = GetBookByID(ID);
            if (temp != null)
            {
                temp.ID = ID;
                temp.AuthorName = book.AuthorName;
                temp.BookName = book.BookName;
                if (_context.SaveChanges() != 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
