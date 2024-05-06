using Labb2Linq.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb2Linq.Data
{
    public class Seed
    {
        //Seeds data to all the tables when running application
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            Console.WriteLine("SeedData method is being executed.");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LinqDbContext>();

                context.Database.Migrate();

                //Makes sure the tables are filled in the right order, due to their relationship keys
                SeedTeachers(context);
                SeedSchoolClasses(context);
                SeedCourses(context);
                SeedStudents(context);
                SeedEnrollments(context);
            }
        }
        //method to seed teachers to database
        private static void SeedTeachers(LinqDbContext context)
        {
            //adds the teachers only if the table is empty
            if (!context.Teachers.Any())
            {
                context.Teachers.AddRange(new List<Teacher>()
            {
                new Teacher() { TeacherFirstName = "Tobias", TeacherLastName = "Landén" },
                new Teacher() { TeacherFirstName = "Reidar", TeacherLastName = "Nilsen" },
                new Teacher() { TeacherFirstName = "Aldor", TeacherLastName = "Besher" },
            });
                context.SaveChanges();
            }
        }
        // seed school classes to database
        private static void SeedSchoolClasses(LinqDbContext context)
        {
            if (!context.SchoolClasses.Any())
            {
                var teacher = context.Teachers.FirstOrDefault(t => t.TeacherFirstName.Contains("Tobias"));
                var teacher2 = context.Teachers.FirstOrDefault(t => t.TeacherFirstName.Contains("Aldor"));

                context.SchoolClasses.AddRange(new List<SchoolClass>()
            {
                new SchoolClass() { SchoolClassName = ".NET23", FkTeacherId = teacher?.TeacherId },
                new SchoolClass() { SchoolClassName = ".NET24", FkTeacherId = teacher2?.TeacherId },
            });
                context.SaveChanges();
            }
        }
        // Seed courses to database
        private static void SeedCourses(LinqDbContext context)
        {
            if (!context.Courses.Any())
            {


                context.Courses.AddRange(new List<Course>()
            {
                new Course()
                {
                    CourseName = "Programmering 1",
                    CourseDescription = "Grunderna i programmering, i språket C#",
                    StartDate = DateTime.Now.AddDays(2),
                    EndDate = DateTime.Now.AddDays(90),

                },
                new Course()
                {
                    CourseName = "Programmering 2",
                    CourseDescription = "Fortsättning av programmering 1",
                    StartDate = DateTime.Now.AddDays(91),
                    EndDate = DateTime.Now.AddDays(178),

                }
            });
                context.SaveChanges();
            }
        }
        // Seed students to database
        private static void SeedStudents(LinqDbContext context)
        {
            if (!context.Students.Any())
            {
                var net23 = context.SchoolClasses.FirstOrDefault(sc => sc.SchoolClassName.Contains(".NET23"));
                var net24 = context.SchoolClasses.FirstOrDefault(sc => sc.SchoolClassName.Contains(".NET24"));

                context.Students.AddRange(new List<Student>()
            {
                new Student() { StudentFirstName = "Emma", StudentLastName = "Lind", PersonalNumber = "19960101-1221", FkSchoolClassId=net23.SchoolClassId },
                new Student() { StudentFirstName = "Embert", StudentLastName = "Lindor", PersonalNumber = "19960102-1211",FkSchoolClassId=net24.SchoolClassId },
                new Student() { StudentFirstName = "Emson", StudentLastName = "Lindson", PersonalNumber = "19960103-1231",FkSchoolClassId=net23.SchoolClassId }
            });
                context.SaveChanges();
            }
        }
        // Seed enrollments to database
        private static void SeedEnrollments(LinqDbContext context)
        {
            if (!context.Enrollments.Any())
            {
                var student = context.Students.FirstOrDefault(s => s.StudentFirstName.Contains("Emma"));
                var student2 = context.Students.FirstOrDefault(s => s.StudentFirstName.Contains("Embert"));
                var student3 = context.Students.FirstOrDefault(s => s.StudentFirstName.Contains("Emson"));

                var course = context.Courses.FirstOrDefault(c => c.CourseName.Contains("Programmering 1"));
                var course2 = context.Courses.FirstOrDefault(c => c.CourseName.Contains("Programmering 2"));

                var teacher3 = context.Teachers.FirstOrDefault(t => t.TeacherFirstName.Contains("Reidar"));
                var teacher4 = context.Teachers.FirstOrDefault(t => t.TeacherFirstName.Contains("Aldor"));

                context.Enrollments.AddRange(new List<Enrollment>()
            {
                new Enrollment() { FkStudentId = student.StudentId, FkCourseId = course.CourseId,  FkTeacherId = teacher3?.TeacherId },
                new Enrollment() { FkStudentId = student2.StudentId, FkCourseId = course.CourseId, FkTeacherId = teacher3?.TeacherId },
                new Enrollment() { FkStudentId = student3.StudentId, FkCourseId = course2.CourseId, FkTeacherId = teacher4?.TeacherId },
                new Enrollment() { FkStudentId = student2.StudentId, FkCourseId = course2.CourseId, FkTeacherId = teacher4?.TeacherId },
                });
                context.SaveChanges();
            }
        }
    }
}

