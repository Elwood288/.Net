using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET api/students
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentService.GetAll());
        }

        // GET api/students/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentService.Get(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        // POST api/students
        [HttpPost]
        public IActionResult Post([FromBody] Student newStudent)
        {
            Student student;
            try
            {
                student = _studentService.Add(newStudent);
            }
            catch(ApplicationException ex)
            {
                ModelState.AddModelError("AddStudent", ex.Message);
                return BadRequest(ModelState);
            }
            if (student == null)
                return BadRequest();
            return CreatedAtAction("Get", new { Id = newStudent.Id }, newStudent);
        }

        // PUT api/students/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student updatedStudent)
        {
            var student = _studentService.Update(updatedStudent);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        // DELETE api/students/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _studentService.Get(id);
            if (student == null)
                return NotFound();
            _studentService.Remove(student);
            return NoContent();
        }
    }
}
