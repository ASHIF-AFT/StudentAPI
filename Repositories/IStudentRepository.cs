using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAPI.Models;

namespace StudentAPI.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> Get();

        Task<Student> Get(int id);

        Task<Student> Create(Student student);

        Task Update(Student student);

        Task Delete(int id);

        Task<IEnumerable<StudentName>> GetAllStudents(string fieldname, int sortOrder);

    }
}
