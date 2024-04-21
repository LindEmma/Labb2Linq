using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2Linq.Models
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { get; set; }
        [Display(Name ="Inskickad")]
        public DateTime EnrollmentDate { get; set; }
        [ForeignKey("Student")]
        [Display(Name ="Elev")]
        public int FkStudentId { get; set; }
        public Student? Student { get; set; }

        [ForeignKey("Course")]
        [Display(Name = "Kurs")]
        public int FkCourseId { get; set; }
        public Course? Course { get; set; }


        public Enrollment()
        {
            EnrollmentDate = DateTime.Now;
        }
    }
}
