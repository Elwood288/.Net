using BookAPI.Data;
using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _bookContext;

        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        //Get all books
        public IEnumerable<Book> GetAll()
        {
            return _bookContext.books.ToList();
        }

        //Get a book by id
        public Book Get(int id)
        {
            return _bookContext.books.FirstOrDefault(b => b.Id == id);
        }

        //Add a new book
        public Book Add(Book newBook)
        {
            _bookContext.Add(newBook);
            _bookContext.SaveChanges();
            return newBook;
        }

        //Update Book
        public Book Update(Book updatedBook)
        {
            var currentBook = _bookContext.books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (currentBook == null) return null;
            _bookContext.Entry(currentBook).CurrentValues.SetValues(updatedBook);
            _bookContext.Update(currentBook);
            _bookContext.SaveChanges();
            return currentBook;
        }

        //Delete book
        public void Delete(Book book)
        {
            var currentBook = _bookContext.books.Find(book.Id);
            if (currentBook == null) return;
            _bookContext.books.Remove(book);
            _bookContext.SaveChanges();
        }
    }
}
