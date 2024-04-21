using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2Linq.Models
{
    public class SchoolClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolClassId { get; set; }
        [Required]
        [Display(Name ="Klass")]
        public string SchoolClassName { get; set; } = string.Empty;
        [ForeignKey("Teacher")]
        public int? FkTeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
