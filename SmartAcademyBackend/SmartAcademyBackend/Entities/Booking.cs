using SmartAcademyBackend.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartAcademyBackend.Entities
{
    public class Booking
    {

        [Key]
        public int BookingId { get; set; }
        public int StudentId { get; set; }
        public  Student? Student { get; set; }
        public int TutorId { get; set; }
        public  Tutor? Tutor { get; set; }
        public int SubjectId { get; set; }
        public  Subjects? Subjects { get; set; }
        public int TutorAvailabilityId { get; set; } 
        public TutorAvailability? TutorAvailability { get; set; }
        public AttendanceType AttendanceType { get; set; }
        public BookingStatus BookingStatus { get; set; } = BookingStatus.Pending;
        public DateOnly Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
