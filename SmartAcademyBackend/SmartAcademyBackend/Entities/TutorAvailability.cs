using SmartAcademyBackend.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartAcademyBackend.Entities
{
    public class TutorAvailability
    {
        [Key]
        public int TutorAvailabilityId { get; set; }
        public int TutorId { get; set; }
        public  Tutor? Tutor { get; set; }
        public required DaysOfTheWeek Day { get; set; }
        public int TimeSlotId { get; set; }
        public  TimeSlots? TimeSlots { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
