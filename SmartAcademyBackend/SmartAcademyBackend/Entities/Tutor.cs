using SmartAcademyBackend.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartAcademyBackend.Entities
{
    public class Tutor
    {
        [Key]
        public int TutorId { get; set; }

        public required string TutorName { get; set; }
        public required string TutorSurname { get; set; }
        public required string ContactNumber { get; set; }
        public required string TutorBio { get; set; }
        public required TeachingMode TeachingMode { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<TutorAvailability> TutorAvailabilities { get; set; } = new List<TutorAvailability>();
        public ICollection<Subjects> Subjects { get; set; } = new List<Subjects>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
