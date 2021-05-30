using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        public DbSet<Class> Class { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<ReportCard> ReportCard { get; set; }
    }
}
