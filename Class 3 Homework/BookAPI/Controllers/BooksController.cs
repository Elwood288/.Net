using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Models;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_bookService.GetAll());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var book = _bookService.Get(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] Book newBook)
        {
            Book book;
            try
            {
                book = _bookService.Add(newBook);
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("AddBook", ex.Message);
                return BadRequest(ModelState);
            }
            if (book == null)
                return BadRequest();
            return CreatedAtAction("Get", new { Id = newBook.Id }, newBook);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book updatedBook)
        {
            var book = _bookService.Update(updatedBook);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.Get(id);
            if (book == null)
                return NotFound();
            _bookService.Delete(book);
            return NoContent();
        }
    }
}
