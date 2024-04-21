using Labb2Linq.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb2Linq.Data
{
    public class LinqDbContext : DbContext
    {
        public LinqDbContext(DbContextOptions<LinqDbContext> options)
         : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
