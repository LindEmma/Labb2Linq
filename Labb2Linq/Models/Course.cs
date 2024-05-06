using Labb2Linq.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2Linq.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Display(Name = "Kurs")]
        [Required]
        public string CourseName { get; set; } = string.Empty;
        [Display(Name = "Kursbeskrivning")]
        public string? CourseDescription { get; set; } = string.Empty;
        [Display(Name = "Betyg")]
        public Grades? CourseGrade { get; set; }
        public virtual ICollection<Enrollment>? Enrollments { get; set; }

    }
}
