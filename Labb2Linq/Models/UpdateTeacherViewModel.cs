namespace Labb2Linq.Models
{
    public class UpdateTeacherViewModel
    {
        public int SelectedStudentId { get; set; }
        public int SelectedTeacherId { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
