using System.ComponentModel.DataAnnotations;

namespace Labb2Linq.Models
{
    public class TeacherCourseViewModel
    {
        [Display(Name = "Kurs")]
        public string CourseName { get; set; }
        [Display(Name = "Lärare")]
        public string TeacherFullName { get; set; }

        public TeacherCourseViewModel(string courseName, string teacherFirstName, string teacherLastName)
        {
            CourseName = courseName;
            TeacherFullName = $"{teacherFirstName} {teacherLastName}";
        }
    }
}
