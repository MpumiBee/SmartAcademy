using System.ComponentModel.DataAnnotations;

namespace SmartAcademyBackend.Entities
{
    public class TimeSlots
    {
        [Key]
        public int TimeSlotId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public ICollection<TutorAvailability> TutorAvailabilities { get; set; } = new List<TutorAvailability>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

