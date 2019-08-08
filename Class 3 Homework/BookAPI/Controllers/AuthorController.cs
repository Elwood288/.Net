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
    public class AuthorsController : ControllerBase
    {
        private IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        // GET api/authors
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_authorService.GetAll());
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var author = _authorService.Get(id);
            if (author == null)
                return NotFound();
            return Ok(author);
        }

        // POST api/authors
        [HttpPost]
        public IActionResult Post([FromBody] Author newAuthor)
        {
            Author author;
            try
            {
                author = _authorService.Add(newAuthor);
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("AddAuthor", ex.Message);
                return BadRequest(ModelState);
            }
            if (author == null)
                return BadRequest();
            return CreatedAtAction("Get", new { Id = newAuthor.Id }, newAuthor);
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author updatedAuthor)
        {
            var author = _authorService.Update(updatedAuthor);
            if (author == null)
                return NotFound();
            return Ok(author);
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _authorService.Get(id);
            if (book == null)
                return NotFound();
            _authorService.Delete(book);
            return NoContent();
        }
    }
}
