using System.ComponentModel.DataAnnotations;

namespace SmartAcademyBackend.Entities
{
    public class Subjects
    {
        [Key]
        public int SubjectID { get; set; }
        public required string SubjectName { get; set; }

        public ICollection<Tutor> Tutors { get; set; } = new List<Tutor>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
