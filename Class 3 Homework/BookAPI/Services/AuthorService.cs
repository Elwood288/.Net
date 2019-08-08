using BookAPI.Data;
using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookContext _bookContext;

        public AuthorService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        //Get all authors
        public IEnumerable<Author> GetAll()
        {
            return _bookContext.authors.ToList();
        }

        //Get an author by id
        public Author Get(int id)
        {
            return _bookContext.authors.FirstOrDefault(a => a.Id == id);
        }

        //Add a new author
        public Author Add(Author newAuthor)
        {
            _bookContext.Add(newAuthor);
            _bookContext.SaveChanges();
            return newAuthor;
        }

        //Update author
        public Author Update(Author updatedAuthor)
        {
            var currentAuthor = _bookContext.authors.FirstOrDefault(a => a.Id == updatedAuthor.Id);
            if (currentAuthor == null) return null;
            _bookContext.Entry(currentAuthor).CurrentValues.SetValues(updatedAuthor);
            _bookContext.Update(currentAuthor);
            _bookContext.SaveChanges();
            return currentAuthor;
        }

        //Delete author
        public void Delete(Author author)
        {
            var currentAuthor = _bookContext.books.Find(author.Id);
            if (currentAuthor == null) return;
            _bookContext.authors.Remove(author);
            _bookContext.SaveChanges();
        }

        public Author GetAuthorBooks(int id)
        {
           
            var authorBooks = _bookContext.authors
                            .Include(a => a.Books) 
                            .SingleOrDefault(a=>a.Id==id);
            return authorBooks;
        }
    }
}
