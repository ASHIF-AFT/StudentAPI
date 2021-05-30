using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;
namespace StudentAPI.Repositories
{
    public class ClassRepository : IClassRepository
    {

        private readonly SchoolContext _context;
        public ClassRepository(SchoolContext context)
        {
            _context = context;
        }
        public async Task<Class> Create(Class classs)
        {
            _context.Class.Add(classs);
            await _context.SaveChangesAsync();
            return classs;
        }

        public async Task Delete(int id)
        {
            var classToDelete = await _context.Student.FindAsync(id);
            _context.Student.Remove(classToDelete);
            await _context.SaveChangesAsync();
        }

        public async  Task<IEnumerable<Class>> Get()
        {
            return await _context.Class.ToListAsync();
        }

        public async Task<Class> Get(int id)
        {
            return await _context.Class.FindAsync(id);
        }

        public async Task Update(Class classs)
        {
            _context.Entry(classs).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
