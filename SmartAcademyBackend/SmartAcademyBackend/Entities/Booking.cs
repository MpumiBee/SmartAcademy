using SmartAcademyBackend.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartAcademyBackend.Entities
{
    public class Booking
    {

        [Key]
        public int BookingId { get; set; }
        public int StudentId { get; set; }
        public required Student Student { get; set; }
        public int TutorId { get; set; }
        public required Tutor Tutor { get; set; }
        public int SubjectId { get; set; }
        public required Subjects Subjects { get; set; }
        public int TimeSlotId { get; set; }
        public required TimeSlots TimeSlots { get; set; }
        public AttendanceType AttendanceType { get; set; }
        public BookingStatus BookingStatus { get; set; } = BookingStatus.Pending;
        public DateOnly Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
