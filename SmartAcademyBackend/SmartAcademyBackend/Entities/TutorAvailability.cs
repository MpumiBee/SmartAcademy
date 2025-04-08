using SmartAcademyBackend.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartAcademyBackend.Entities
{
    public class TutorAvailability
    {
        [Key]
        public int TutorAvailabilityId { get; set; }
        public int TutorId { get; set; }
        public required Tutor Tutor { get; set; }
        public required DaysOfTheWeek Day { get; set; }
        public int TimeSlotId { get; set; }
        public required TimeSlots TimeSlots { get; set; }
    }
}
