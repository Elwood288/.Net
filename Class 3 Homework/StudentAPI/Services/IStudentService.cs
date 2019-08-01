using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAPI.Models;

namespace StudentAPI.Services
{
    public interface IStudentService
    {

        IEnumerable<Student> GetAll();
        Student Get(int id);
        Student Add(Student newStudent);
        Student Update(Student updatedStudent);
        void Remove(Student _student);
    }
}
