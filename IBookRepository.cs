using BookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBookByID(string ID);
        bool AddBook(Book book);
        bool ModifyBookDetails(string ID, Book  book);
    }
}
