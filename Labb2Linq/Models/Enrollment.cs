using Labb2Linq.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2Linq.Models
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { get; set; }

        [Display(Name = "Ansökningsdatum")]
        public DateTime EnrollmentDate { get; set; }

        [ForeignKey("Student")]
        [Display(Name = "Elev Id")]
        public int FkStudentId { get; set; }
        [Display(Name = "Elev")]
        public Student? Student { get; set; }

        [ForeignKey("Course")]
        [Display(Name = "Kurs Id")]
        public int FkCourseId { get; set; }
        [Display(Name = "Kurs")]
        public Course? Course { get; set; }

        [ForeignKey("Teacher")] // Lägg till ForeignKey för Teacher
        [Display(Name = "Lärar Id")]
        public int? FkTeacherId { get; set; }
        [Display(Name = "Lärare")]
        public Teacher? Teacher { get; set; } // Lägg till Teacher här

        [Display(Name = "Antagningssbesked")]
        public Acceptance Acceptance { get; set; } = Acceptance.Pending;

        public Enrollment()
        {
            EnrollmentDate = DateTime.Now;
        }
    }
}
