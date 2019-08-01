using System;
using Xunit;
using StudentAPI.Models;
using StudentAPI.Services;
using StudentAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Student_API_UniTest
{
    public class UnitTest
    {
        [Fact]
        public void Post_ShoulReturnBadRequestIfBirthDatIsInFuture()
        {
            
            Student student = new Student()
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2999, 1, 1), // in the future
                Email = "test@test.com",
                Phone = "555-555-5555"
            };

            var result = TryPost(student);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_ShouldReturnBadRequestIfBirthdayIsTooOld()
        {
            Student student = new Student()
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2000, 1, 1), // too old
                Email = "test@test.com",
                Phone = "555-555-5555"
            };

            var result = TryPost(student);
            Assert.IsType<BadRequestObjectResult>(result);
        }
        public IActionResult TryPost(Student student)
        {
            StudentsController controller = new StudentsController(new StudentService());
            var result = controller.Post(student);
            return result;
        }
    }
}
