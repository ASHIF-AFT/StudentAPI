using StudentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository()
        {
        }

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<Student> Create(Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task Delete(int id)
        {
            var studentToDelete = await _context.Student.FindAsync(id);
            _context.Student.Remove(studentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> Get()
        {
            return await _context.Student.ToListAsync();
         }

        public async Task<Student> Get(int id)
        {
            return await _context.Student.FindAsync(id);
        }

        public async Task<IEnumerable<StudentName>> GetAllStudents(string fieldname, int sortOrder)
        {
            
            var studentObjects = from student in _context.Student select student;
            if (sortOrder == 1)
            {
                if (fieldname == "Roll_Number")
                {
                    studentObjects = (IQueryable<Student>)studentObjects.OrderBy(x => x.Roll_Number);
                }
                else if (fieldname == "Name")
                {
                    studentObjects = (IQueryable<Student>)studentObjects.OrderBy(x => x.Name);
                }
                else if (fieldname == "Class")
                {
                    studentObjects = (IQueryable<Student>)studentObjects.OrderBy(x => x.Class);
                }
            }
            else if (sortOrder == -1)
            {
                if (fieldname == "Roll_Number")
                {
                    studentObjects = (IQueryable<Student>)studentObjects.OrderByDescending(x => x.Roll_Number);
                }
                else if (fieldname == "Name")
                {
                    studentObjects = (IQueryable<Student>)studentObjects.OrderByDescending(x => x.Name);
                }
                else if (fieldname == "Class")
                {
                    studentObjects = (IQueryable<Student>)studentObjects.OrderByDescending(x => x.Class);
                }
            }
            List<StudentName> studentNames = (from student in studentObjects select new StudentName() { Name = student.Name }).ToList();

            /*var studentNames = from student in studentObjects select new { student.Name };*/
            

            return studentNames;



            // older method
            /*            var allStudents = await _context.Student.ToListAsync();
                        List<Student> studentObjects = new List<Student>();
                        List<string> studentNames = new List<string>();
                        foreach (var student in allStudents)
                        {
                            studentObjects.Add(student);
                        }
                        if (sortOrder == 1)
                        {
                            if (fieldname == "Roll_Number")
                            {
                                studentObjects = studentObjects.OrderBy(x => x.Roll_Number).ToList();
                            }
                            else if (fieldname == "Name")
                            {
                                studentObjects = studentObjects.OrderBy(x => x.Name).ToList();
                            }
                            else if (fieldname == "Class")
                            {
                                studentObjects = studentObjects.OrderBy(x => x.Class).ToList();
                            }
                        }
                        else if (sortOrder == -1)
                        {
                            if (fieldname == "Roll_Number")
                            {
                                studentObjects = studentObjects.OrderByDescending(x => x.Roll_Number).ToList();
                            }
                            else if (fieldname == "Name")
                            {
                                studentObjects = studentObjects.OrderByDescending(x => x.Name).ToList();
                            }
                            else if (fieldname == "Class")
                            {
                                studentObjects = studentObjects.OrderByDescending(x => x.Class).ToList();
                            }
                        }

                        foreach (var student in studentObjects)
                        {
                            studentNames.Add(student.Name);
                        }
                        return (IEnumerable<string>)studentNames;*/
        }

        public async Task Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
