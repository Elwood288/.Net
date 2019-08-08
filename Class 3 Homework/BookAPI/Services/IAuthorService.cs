using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAll();
        Author Get(int id);
        Author Add(Author newBook);
        Author Update(Author updatedBook);
        void Delete(Author book);
    }
}
