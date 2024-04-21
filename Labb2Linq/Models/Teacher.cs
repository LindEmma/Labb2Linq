using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2Linq.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        [Display(Name ="Förnamn")]
        public string TeacherFirstName { get; set; } = string.Empty;
        [Display(Name = "Efternamn")]
        public string TeacherLastName { get; set; } = string.Empty;
    }
}
